/*
 * Robot_arm_atmega_2560.c
 *
 * Created: 10/3/2014 2:52:44 PM
 *  Author: Buddhika Jayawardhana
 */ 



#define F_CPU 16000000UL

#include <avr/io.h>
#include <util/delay.h>
#include <stdio.h>
#include <avr/interrupt.h>

/*CONVENTIONS*/

#define  numMotors 7//number of motors//Assumed as right
#define LEFT 0//left direction of the motor
#define RIGHT 1//right direction of the motor
#define RISEnLOWDIR 0//direction of the motor when ENCA is a rising edge//ENCB is low, Assumed as left
#define RISEnHIGHDIR 1//direction of the motor when ENCA is a rising edge//ENCB is high, positive direction, Assumes as RIGHT
#define TRUE 1
#define FALSE 0
#define SWITCHE_PRESSED 0//define the state of the pin when the switch is pressed

/*PINS*/

//SWITCH:	define the the pins connected to the switch of each motor below
#define SWITCH_DDR DDRJ
#define SWITCH_PORT PORTJ
#define SWM0 PJ0 //PCINT9
//ENCODER_PIN_A:	interrupt pins which are connected to encoder pin A of each motor below
#define ENCAM0 PD0//connected to INT0
//ENCODER_PIN_B:	define the general I/O pins which are connected to encoder pin B of each motor below
#define ENCB_DDR DDRA
#define ENCB_PORT PORTA
#define ENCB_PIN PINA
#define ENCBM0 PA0

/*CONTROL PINS*/
//PWM (enable) pins for motors //PB 4:7 & PH 3:6
#define ENABLE_PORT1 PORTB
#define ENABLE_PORT2 PORTH 
#define ENM0 PB4
//direction controlling I/O pins PB 0:4
#define DIRECTION_DDR DDRB
#define DIRECTION_PORT PORTB
#define DIRM0 PB0

/*iNTERRUPS*/
//External interrupts
#define ENCAM0_EINTVECT INT0_vect
//pin change interrupts
#define SWM0_PCINTVECT PCINT1_vect


/* THE LOGIC
*The Motor structure defines the attributes
of a Motor.
*Seven Motor structures for seven motors.
*Commands and Interrupts change the attribute of each Motor
*Poll function then make the decision by looking at each Motor structure
*/
struct Motor{
	int running;
	int direction;//current rotating direction: LEFT or RIGHT
	int relativeRevolutions;//number of revolutions relative to the home
	int HomeSwitchState;
	int maxRevolutionsRight;//Right safety limit
	int maxRevolutionsLeft;//Left safety limit
	int ENCB;//TRUE if high
	int targetDirection;//target direction to rotate
	int targetPosition;//target position to stop
};

struct Motor *M0;

/*FUNCTIONS*/
void motorObjectSetup(struct Motor *motor);//assign initial attributes to Motors
void pinSetup();//Setup DDR pins
void initialize();//Checks state of all Motors before executing the program.
void checkHomeSwiches(struct Motor *motor);//check the state of the position indicating switch of the motor.
void pollMotor(struct Motor *motor);//THE LOGIC IS HERE. Checks all the Motors and decide what to do.

void testNow();//Testing purposes

int main(void){
	struct Motor MtestM;
	M0 = &MtestM;
	pinSetup();
	initialize();
	motorObjectSetup(M0);
	sei();//enable global interrupt
	testNow();
	while(1){
		pollMotor(M0);
	
	}
	return 0;
	
}

/*
*Motor 0:Encoder pin A:Rising Edge Detecting Function
*Counts encoder ticks
*Updates the direction of the Motor
*/
ISR(ENCAM0_EINTVECT){
	cli();
	if((ENCB_PIN&0x1)==0x1){
		M0->relativeRevolutions++;
		M0->direction = RISEnHIGHDIR;
		
	}
	else{
		M0->relativeRevolutions--;
		M0->direction = RISEnLOWDIR;
	}
	sei();
}

/*
*Motor 0:Home Switch state:Pin Change Detecting Function
*Toggles the  homeSwitchState attribute of the motor
*/
ISR(SWM0_PCINTVECT){
	cli();
	//toggle the state of home switch state
	if(M0->HomeSwitchState == TRUE){
		M0->HomeSwitchState = FALSE;
	}
	else{
		M0->HomeSwitchState =TRUE;
	}
	sei();
}


void motorObjectSetup(struct Motor *motor){
	motor->running = TRUE;
	motor->targetDirection = LEFT;
	motor->maxRevolutionsLeft = -1000;
	motor->maxRevolutionsRight = 1000;
	motor->relativeRevolutions = 0;
	motor->targetPosition = -300;

}

void pinSetup(){
	DDRJ = 0x0;//PCINT for switches
	DDRD = 0x1E;//INT for Encoder-A
	DDRE = 0xF0;//INT for Encoder-A
	DDRA = 0;
	
	//temp code
	DDRB = 0xFF;//PWM and Direction controlling
	
	//end temp code
	
	
	//Setup external interrupts
	EIMSK = 0xFF;//Enabling interrupts 7:0
	EICRA = 0xFF;//Enabling Rising edge interrupts for INT 3:0
	EICRB = 0xFF;//Enabling Rising edge interrupts for INT 7:4
	//setup pin change interrupts
	PCMSK1 = 0xFF;//Enabling PCinterrupts 15:8, but we want only 15:9/J6:J0
	PCICR = (1<<PCIE1);//Enabling PCinterrupts 15:8, but we want only 15:9/J6:J0 
}
void initialize(){
	checkHomeSwiches(M0);
	
}
//more work here:How to pass SWM0????
void checkHomeSwiches(struct Motor *motor){
	if(SWM0 == SWITCHE_PRESSED){
		motor->HomeSwitchState = SWITCHE_PRESSED;
	}
	else{
		motor->HomeSwitchState = !SWITCHE_PRESSED;
	}
}

void pollMotor(struct Motor *motor){
	//run/stop motor
	if(motor->running == TRUE){
		ENABLE_PORT1 = (TRUE<<ENM0);
	}
	else{
		ENABLE_PORT1 = (FALSE<<ENM0);
	}
	//change the rotating direction
	if(motor->targetDirection == RIGHT){//rotate right
		DIRECTION_PORT = (RIGHT<<DIRM0)|(DIRECTION_PORT);
	}
	else if(motor->targetDirection == LEFT){//rotate left
		DIRECTION_PORT = (LEFT<<DIRM0)|(DIRECTION_PORT);
	}
	//stop the motor if safety limits reached
	if(((motor->relativeRevolutions)>= (motor->maxRevolutionsRight))||((motor->relativeRevolutions)<=(motor->maxRevolutionsLeft))){
		motor->running = FALSE;
	}
	//stop at target position
	if(!((motor->relativeRevolutions)-(motor->targetPosition))){
		motor->running = FALSE;
	}
}

void testNow(){
	PORTB = ((1<<PB7)|(PORTB));
	_delay_ms(500);
	PORTB = ((0<<PB7)|(PORTB));
	_delay_ms(500);
	
	M0->targetDirection = LEFT;
	pollMotor(M0);	
}


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
#define ENCBM0 PA0

/*DEFINE THE CONTROL PINS*/
//PWM (enable) pins for motors //PB 4:7 & PH 3:6
#define RUNPORTB PORTB
#define RUNPORTH PORTH
#define RUNM0 PB4
//direction controlling I/O pins PB 0:4
#define DIRECTIONPORT PORTB
#define DIRM0 PB0


struct Motor{
	int running;
	//direction of rotation -1:left,0:none, 1:right
	//(current rotating direction of the motor)
	int direction;
	//number of revolutions relative to the home
	int relativeRevolutions;
	int HomeSwitchState;
	int maxRevolutionsRight;
	int maxRevolutionsLeft;
	int ENCB;//TRUE if high
	//command attributes these attributes should be changed when you want to execute a command
	int directionToRotate;//set the direction the motor should rotate
};

struct Motor *M0;

//initializing functions
void motorObjectSetup(struct Motor *motor);
void pinSetup();
void initialize();
	//initializing utilities
	void checkHomeSwiches(struct Motor *motor);


//check functions
void pollMotor(struct Motor *motor);
void setENCB(struct Motor *motor);

//commands
void stopAtHome();//stops the motors if they are in home position
void rotateRight();

int main(void){
	struct Motor MtestM;
	M0 = &MtestM;
	pinSetup();
	sei();//enable global interrupt
	motorObjectSetup(M0);
	initialize();
	//test start
	PORTB = (1<<PB7);
	_delay_ms(200);
	PORTB = (0<<PB7);
	_delay_ms(200);
	PORTB = (1<<PB7);
	_delay_ms(200);
	PORTB = (0<<PB7);
	_delay_ms(200);
	//test end
	while(1){

		M0->directionToRotate=LEFT;
		pollMotor(M0);
		_delay_ms(500);
		M0->directionToRotate=RIGHT;
		pollMotor(M0);
		_delay_ms(500);

	}
	return 0;

}


//poll at ENCB pin of the motor
void setENCB(struct Motor *motor){
	if(ENCBM0 == TRUE ){
		motor->ENCB = TRUE;
	}
	else{
		motor->ENCB = FALSE ;
	}
}

//Encoder-A Interrupt detecting function
//this is activated when a rising edge is detected by ENCA of the motor
//this function is written for Motor0 and you should write a dedicated function for
//each motor
ISR(INT0_vect){
	cli();
	/*
	if(M0->ENCB == TRUE){
		M0->relativeRevolutions++;
		//M0->direction = RISEnHIGHDIR;

	}
	else{//put elseif
		M0->relativeRevolutions--;
		M0->direction = RISEnLOWDIR;
	}*/

	//_delay_ms(5);
	if((PINA&0x1)==0x1){
		M0->relativeRevolutions++;
		M0->direction = RISEnHIGHDIR;

	}
	else{//put elseif
		M0->relativeRevolutions--;
		M0->direction = RISEnLOWDIR;
	}
	sei();
}
//CHECK HOME SWITCH
//this function detects the state changes of home switch
//when ever pin change is detected it resets the relative position to 0
ISR(PCINT1_vect){
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

/*
	COMMANDS
*/
//this is a command function to stop at home
void stopAtHome(struct Motor *motor){
	if(motor->HomeSwitchState == TRUE){
		motor->running = FALSE;
	}
}

/*INITIALIZING*/
	void motorObjectSetup(struct Motor *motor){
	motor->running = TRUE;
	motor->directionToRotate = LEFT;
	motor->maxRevolutionsLeft = -1000;
	motor->maxRevolutionsRight = 1000;
	motor->relativeRevolutions = 0;

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
	EIMSK = 0xFF;//Enabling interrups 7:0
	EICRA = 0xFF;//Enabling Rising edge interrupts for INT 3:0
	EICRB = 0xFF;//Enabling Rising edge interrupst for INT 7:4
	//setup pin change interrups
	PCMSK1 = 0xFF;//Enabling PCinterrupts 15:8, but we want only 15:9/J6:J0
	PCICR = (1<<PCIE1);//Enabling PCinterrupts 15:8, but we want only 15:9/J6:J0
}
void initialize(){
	checkHomeSwiches(M0);

}

/*INIT UTILITIES*/

void checkHomeSwiches(struct Motor *motor){
	//set the switch state before begin
	//have to write following code for each motor
	if(SWM0 == SWITCHE_PRESSED){
		motor->HomeSwitchState = SWITCHE_PRESSED;
	}
	else{
		motor->HomeSwitchState = !SWITCHE_PRESSED;
	}
}

//main poll function
//only for testing M0
void pollMotor(struct Motor *motor){
	//run stop motor
	if(motor->running == TRUE){
		RUNPORTB = (TRUE<<RUNM0);
	}
	else{
		RUNPORTB = (FALSE<<RUNM0);
	}
	//change the rotating direction
	if(motor->directionToRotate == RIGHT){//rotate right
		DIRECTIONPORT = (RIGHT<<DIRM0)|(DIRECTIONPORT);
		//PORTB = (1<<PB0)|(PORTB);
	}
	else if(motor->directionToRotate == LEFT){//rotate left
		DIRECTIONPORT = (LEFT<<DIRM0)|(DIRECTIONPORT);
		//PORTB = (0<<PB0)|(PORTB);
	}
	//stop the motor if limits reached
	if(((motor->relativeRevolutions)>= (motor->maxRevolutionsRight))||((motor->relativeRevolutions)<=(motor->maxRevolutionsLeft))){
		motor->running = FALSE;
	}
	//test check the switch
	if(motor->HomeSwitchState == SWITCHE_PRESSED){//test
		PORTB = ((1<<PB7)|(PORTB));
		//_delay_ms(500);
	}
	else{
		PORTB = ((0<<PB7)|(PORTB));
		//_delay_ms(500);
	}
	//switch test ends here

}


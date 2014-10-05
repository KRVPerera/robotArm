/*
 * MotorFunctions.h
 *
 * Created: 10/5/2014 10:41:30 AM
 *  Author: Buddhika Jayawardhana
 */ 
 /*This file contains all necessary functions to drive a motor. All functions are written in 
 Object oriented manner EXCEPT "void checkHomeSwiches(struct Motor *motor)". For all other functions
 you only have to pass the reference of the motor.
 *Depends on 
	"ConvensionDefine.h","PinDefine.h","Motor.h","MotorDeclaration.h"
	<avr/io.h>,<avr/interrupt.h>,<util/delay.h>
 
 More work to done on "void checkHomeSwiches(struct Motor *motor)"
 */
 
 
/*FUNCTIONS*/
void motorObjectSetup(struct Motor *motor);//assign initial attributes to Motors
void pinSetup();//Setup DDR pins
void initialize();//Checks state of all Motors before executing the program.
void checkHomeSwiches(struct Motor *motor);//check the state of the position indicating switch of the motor.
void pollMotor(struct Motor *motor);//THE LOGIC IS HERE. Checks all the Motors and decide what to do.

void testNow();//Testing purposes

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
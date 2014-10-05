/*
 * MotorFunctions.h
 *
 * Created: 10/5/2014 12:03:30 PM
 *  Author: Buddhika Jayawardhana
 */ 
 /*
 *This file contains Interrupt Service Routines for each motor.
 *Each motor has 
	*External interrupt for Encoder:A pin
	*Pin-change Interrupt for Home switch
*Depends on
	*<avr/interrupt.h>,"ConvensionDefine.h","MotorDeclaration.h"
 */
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
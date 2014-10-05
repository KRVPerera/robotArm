/*
 * ConvensionDefine.h
 *
 * Created: 10/5/2014 10:42:05 AM
 *  Author: Buddhika Jayawardhana
 */ 
 /*
 This file contains all conventions and pre define values
 This is an independent file
 */
/*CONVENTIONS*/

#define  numMotors 7//number of motors//Assumed as right
#define LEFT 0//left direction of the motor
#define RIGHT 1//right direction of the motor
#define RISEnLOWDIR 0//direction of the motor when ENCA is a rising edge//ENCB is low, Assumed as left
#define RISEnHIGHDIR 1//direction of the motor when ENCA is a rising edge//ENCB is high, positive direction, Assumes as RIGHT
#define TRUE 1
#define FALSE 0
#define SWITCHE_PRESSED 0//define the state of the pin when the switch is pressed
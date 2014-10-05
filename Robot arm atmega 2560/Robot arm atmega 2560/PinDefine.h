/*
 * PinDefine.h
 *
 * Created: 10/5/2014 10:41:30 AM
 *  Author: Buddhika Jayawardhana
 */ 

 /*
*This file defines all the pins of the micro-controller that are used.
*You can know the meaning of each definition by simply reading it.
*Originally this program was developed under ATmega 2560.
*Defining the pins in our own way makes the program "pin independent"
*Depends on
	
 */
 
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
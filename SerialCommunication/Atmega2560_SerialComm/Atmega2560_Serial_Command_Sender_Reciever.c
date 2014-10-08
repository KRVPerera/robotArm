/*
 * Atmega2560SerialCommunication.c
 *
 * Created: 10/7/2014 12:37:30 PM
 *  Author: krv
 */ 
#define F_CPU 16000000UL
#include <avr/io.h>
#include <stdint.h>                     // needed for uint8_t
#include <util/delay.h>
#include <avr/interrupt.h>


#define FOSC 16000000                       // Clock Speed
#define BAUD 9600							//BAUD rate
#define BAUDRS (FOSC/16/BAUD -1)			//BAUD rate scaler

volatile char ReceivedChar ;

void LED_init();
void USART_init();
void USART_Interrupt_EN();
void run_with_interrupt();


void USART_send(  char data);
void USART_putstring();

char USART_recieve();
void recieve_command();

volatile int i = 0;
volatile char COMMAND[5];

int main(void)
{
	USART_init();

	while(1)
    {		
		recieve_command();
		USART_putstring();
    }	
}

void USART_send( char data)
{
	//while the transmit buffer is not empty loop
	while(!(UCSR0A & (1<<UDRE0)));	
	//when the buffer is empty write data to the transmitted
	UDR0 = data;
}

void run_without_interrupt(){
	while( ( UCSR0A & ( 1 << RXC0 ) )==0){}
	ReceivedChar = UDR0;
	UDR0 = ReceivedChar;
	if( ReceivedChar == 'c' || ReceivedChar == 'C' ){
		PORTB |= (1<<PB7);
		_delay_ms(500);
	}
}

char USART_recieve(){
	while( ( UCSR0A & ( 1 << RXC0 ) )==0){}
	return  UDR0;
}

void recieve_command(){
	for( i = 0 ; i < 3 ; i++){
		COMMAND[i]=USART_recieve();
		if(COMMAND[i] == 'X'){
			break;
		}
	}
	COMMAND[i++] = 'X';
}

void USART_putstring()
{
	i = 0;
	while( (COMMAND[i] != 'X')&&(COMMAND[i] !='\0'))
	{
		USART_send(COMMAND[i]);
		//temp++;
		i++;
	}
}

void USART_init(){

	UCSR0B |= ((1<<RXEN0)|(1<<TXEN0));//enable USART receiver and transmitter
	UCSR0C |= ((1<<UCSZ00)|(1<<UCSZ01));// set frame data bit:8 and stop bit 1
	UBRR0H |= (uint8_t)(BAUDRS>>8);	  //set baud rate HIGH bits
	UBRR0L |= (uint8_t)(BAUDRS);	  //set baud rate low bits
}
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

volatile char ReceivedChar = 'c' ;

void LED_init();
void USART_init();
void USART_Interrupt_EN();
void run_without_interrupt();
void run_with_interrupt();


int main(void)
{
	LED_init();
	USART_init();	
	//USART_Interrupt_EN();	
	
    while(1)
    {
		
		run_without_interrupt();
		//run_with_interrupt();
		
		PORTB = 0x00;
    }
	
}

void USART_init(){
	
	UCSR0B = ((1<<RXEN0)|(1<<TXEN0));//|(1 << RXCIE0) |(1 << TXCIE0));			  //enable USART receiver and transmitter
	UCSR0C = ((1<<UCSZ00)|(1<<UCSZ01));		  // set frame data bit:8 and stop bit 1
	UBRR0H = (uint8_t)(BAUDRS>>8);	  //set baud rate HIGH bits
	UBRR0L = (uint8_t)(BAUDRS);	  //set baud rate low bits
	
	//UCSR0C |= (1<<UMSEL00);
}

void USART_Interrupt_EN(){
	//cli();
	UCSR0B |= (1 << RXCIE0);// |(1 << TXCIE0)); // RX complete interrupt
	//UCSR0B |= (1 << RXCIE0);// |(1 << TXCIE0)); // RX complete interrupt
	//sei();
}

void run_with_interrupt(){
	if( (ReceivedChar == 'c') || (ReceivedChar == 'C') ){
		PORTB |= (1<<PB7);
		_delay_ms(500);
	}	
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


void LED_init(){
	DDRB = 0xFF;
	PORTB = 0x00;
}

ISR(USART0_RX_vect,ISR_BLOCK){
	ReceivedChar = UDR0;
	UDR0 = ReceivedChar;
	ReceivedChar = 'c';	
	PORTB = 0xFF;
	_delay_ms(500);
}


ISR(_VECTOR(27)){
	///cli();
	ReceivedChar = UDR0;
	UDR0 = ReceivedChar;
	ReceivedChar = 'c';
	PORTB = 0xFF;
	_delay_ms(500);
	//sei();
}
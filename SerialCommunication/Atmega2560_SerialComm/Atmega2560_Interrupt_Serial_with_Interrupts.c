// This code waits for a character and transmits the character back (with interrupts)

#define F_CPU 16000000UL
#include <avr/io.h>
#include <stdint.h>                     // needed for uint8_t
#include <util/delay.h>
#include <avr/interrupt.h>


#define FOSC 16000000                       // Clock Speed
#define BAUD 9600
#define MYUBRR FOSC/16/BAUD -1


volatile char ReceivedChar;


int main( void )
{
	//cli();
	DDRB = 0xFF;	//LED off
	PORTB = 0x00;
	UCSR0B |= (1 << RXEN0) | (1 << TXEN0);      // Enable receiver and transmitter
						//RX interrupt enabled
	UCSR0C |= (1 << UCSZ01);// | (1 << UCSZ00);    // Set frame: 8data, 1 stp
	
	/*Set baud rate */
	UBRR0H = (( MYUBRR ) >> 8);
	UBRR0L = MYUBRR;
	UCSR0B |= (1 << RXCIE0);
	sei();

	
	while(1)
	{
		
		if( ReceivedChar == 'C' || ReceivedChar == 'c'){
			PORTB |= (1<<PORTB5);
			_delay_ms(500);
		}
		
		PORTB = 0x00;
		_delay_ms(500);
		PORTB = 0xFF;
		_delay_ms(500);
		// Main loop
	}
}

ISR (USART0_RX_vect)
{
	
	ReceivedChar = UDR0;
	UDR0 = ReceivedChar;
	//sei();
}

/*
 * Motor.h
 *
 * Created: 10/5/2014 10:40:44 AM
 *  Author: Buddhika Jayawardhana
 */ 
 
 /*
 This file contains the DEFINITION OF A SINGLE MOTOR. Do not delete/edit any attribute before
 you carefully study the code. If you do edit, Please clearly mention the change at the commit 
 Before you push to the repo.
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
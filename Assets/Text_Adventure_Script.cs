using UnityEngine;
using System.Collections;

public class Text_Adventure_Script : MonoBehaviour {
	string Current_Location = "Attic";
	bool key = false;
	bool crowbar = false;
	float timer = 0.0f;
	float time_out = 90.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		string textBuffer = "Current Location: " + Current_Location;

		if (Current_Location == "Attic") 
		{
			crowbar = false;
			key = false;
			timer = Time.time;
			textBuffer += "\nIt's dark. It's raining..... "; 
			textBuffer += "\nAnd you are locked in this house. \nYour suicidal kidnapper is in the building,";
			textBuffer += "\nYou have in total 90 seconds \nto escape the house. \nrun.";
			textBuffer += "\nPress [W] to go out the window";
			textBuffer += "\nPress [D] to go out the door";

			if ( Input.GetKeyDown(KeyCode.W) ) 
			{
				Current_Location = "Roof";

			}
			else if ( Input.GetKeyDown(KeyCode.D) )
			{
				Current_Location = "Stair Landing";
			}
		}
		else if ( Current_Location == "Roof" )
		{
			textBuffer += "\nWhy did you go out the window? \nIt's dark and rainy. \nYou fell off the roof.";
			textBuffer += "\nDo you want to play again? Press [Z]";
			if (Input.GetKeyDown(KeyCode.Z))
			{
				Current_Location = "Attic";
			}
		}
		else if (Current_Location == "Stair Landing")
		{
			textBuffer += "\nYou have reached a landing. \nYou can continue going down the stairs.\nOr take the door.";
			textBuffer += "\nPress [T] to choose the door";
			textBuffer += "\nPress [R] to continue down the stairs";
			if ( Input.GetKeyDown(KeyCode.R) )
			{ 
				Current_Location = "Basement"; 
			}
			else if ( Input.GetKeyDown(KeyCode.T) )
			{
				Current_Location = "First Floor"; 
			}
		}
		else if (Current_Location == "Basement" )
		{
			textBuffer += "\nThere are 3 doors in front of you. \nThere's always the possibility that\none has a hidden snakepit.";
			textBuffer += "\nPress [B] to choose the door 1";
			textBuffer += "\nPress [N] to choose the door 2";
			textBuffer += "\nPress [M] to choose the door 3";
			if ( Input.GetKeyDown(KeyCode.B) )
			{
				Current_Location = "Room 1";
			}
			else if ( Input.GetKeyDown(KeyCode.N) )
			{
				Current_Location = "Room 2";
			}
			else if ( Input.GetKeyDown(KeyCode.M) )
			{
				Current_Location = "Room 3";
			}
		}
		else if ( Current_Location == "Room 1")
		{
			textBuffer += "\n Congratulations, you found a room \nwith no exit";
			textBuffer += "\n But you also found a key. \nHow useful!";
			key = true;
			textBuffer += "\n Now try to find the exit. \nPress [Y] to go back.";
				if ( Input.GetKeyDown(KeyCode.Y) )
				{
					Current_Location = "Basement";
				}
		}
		else if ( Current_Location == "Room 2" )
		{
			textBuffer += "\nYou chose the room as a snake pit.\n How unfortunate.";
			textBuffer += "\nDo you want to play again? Press [Z]";
			if (Input.GetKeyDown(KeyCode.Z))
			{
				Current_Location = "Attic";
			}
			 
		}
		else if ( Current_Location == "Room 3" )
		{

			if ( key )
			{
				Current_Location = "Outside";
			}
			else
			{
				textBuffer += "\nYou dont have the key. Press [Z] to go back";
					if ( Input.GetKeyDown(KeyCode.Z) )
					{
						Current_Location = "Basement";
					}
			}
		}
		else if ( Current_Location == "Outside")
		{
			textBuffer += "\nCongratulations. \nYou lived.";
			textBuffer += "\nDo you want to play again?";
			textBuffer += "\nPress [Z]";
			if (Input.GetKeyDown(KeyCode.Z))
			{
				Current_Location = "Attic";
			}
					//remember to stop timer here. 
		}
		else if (Current_Location == "First Floor")
		{
				textBuffer += "\nYou can continue down this hallway. \nOr go right into the kitchen.";
				textBuffer += "\nOr go left into the Garage.\nBe wary of drawing your kidnapper's attention.";
				textBuffer += "\nPress [U] to go into the kitchen. \nPress [I] to go down the hallway.";
				textBuffer += "\nPress [O] to go into the garage";
				
				if ( Input.GetKeyDown(KeyCode.I) )
				{
					Current_Location = "Hallway";
				}
				else if (Input.GetKeyDown(KeyCode.U))
				{
					Current_Location = "Kitchen";
				}
				else if(Input.GetKeyDown(KeyCode.O))
				{
					Current_Location = "Garage";
				}
		}
		else if (Current_Location == "Kitchen")
		{
			textBuffer += "\nYour Killer is in here having his last meal. \nJoin him.";
			textBuffer += "\nNow do you want to play again? Press [Z]";
			if (Input.GetKeyDown(KeyCode.Z))
			{
				Current_Location = "Attic";
			}

				
		}
		else if ( Current_Location == "Garage")
		{
				textBuffer += "\nHey, you found a crowbar! That's useful.";
				crowbar = true;
				textBuffer += "\nPress [C] to go back and look for a way out";
				if( Input.GetKeyDown(KeyCode.C))
				{
					Current_Location = "First Floor";
				}
		}
		else if ( Current_Location == "Hallway")
		{
				textBuffer +="\nThere's a door with a few pieces of wood on \nand a window nailed shut.";
				textBuffer +="\nWhich do you want to try? \nPress [X] for window \nand [P] for door.";
				if (Input.GetKeyDown(KeyCode.X))
				{
					Current_Location = "Trying the window";
				}
				else if (Input.GetKeyDown(KeyCode.P))
				{
					Current_Location = "Trying the door";
				}
		}
		else if( Current_Location == "Trying the window")
		{
			if(crowbar)
			{
				Current_Location = "Outside";
			}
			else{
				textBuffer += "\nYou can't open this with your hands. \n Press [K] to go back and look.";
				if (Input.GetKeyDown(KeyCode.K))
				{
					Current_Location = "First Floor";
				}
			}
			
		}
		else if (Current_Location == "Trying the door")
		{	if (crowbar)
			{
			textBuffer += "\nIt look's like you attracted the killer's attention.";
			textBuffer += "\nDo you want to play again?\n Press [Z]";
				if (Input.GetKeyDown(KeyCode.Z))
				{
					Current_Location = "Attic";
				}
			}
			else
			{
				textBuffer += "\nYou can't open this with your hands.\nPress [K] to go back and look";
				if (Input.GetKeyDown(KeyCode.K))
				{
					Current_Location = "First Floor";
				}
			}
		}
		else if (Current_Location == "Limbo")
		{
			textBuffer += "\nYou ran out of time and blew up.";
			textBuffer +="\nDo you want to play again? \nPress [P]";

			if (Input.GetKeyDown(KeyCode.P))
			{
				timer = Time.time;
				Current_Location = "Attic";
			}
		}

		if ( (Time.time - timer) > time_out )
		{
			Current_Location = "Limbo";
		}

		GetComponent<TextMesh> ().text = textBuffer;
	}
}

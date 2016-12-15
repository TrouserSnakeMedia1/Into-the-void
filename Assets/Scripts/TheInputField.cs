using UnityEngine;
using System.Collections;

public class TheInputField : MonoBehaviour {
	private string textFieldString = "";// nothing is being displayed in the text area. 
	[SerializeField]
	public string eneterPassword,passwordNeededToPass;// instructions that are shown above the text field to input the password
	// the password that is needed to pass the puzzle. it can be alphanumeric values. 
	[SerializeField]
	GameObject door;
	public bool win = false;		
	[SerializeField]
	public int rectX,rectY,labelWidth,labelHeight,textFieldX,textFieldY,textWidth,textHeight,characterLimit;	// the label's rect x
	// the label's rect y
	// the label width
	// the label height
	// text field rect x
	// text field rect y 
	// text field width
	// text field height
	// character limit for the text field

	void OnGUI(){		
		textFieldString = GUI.TextField (new Rect (textFieldX, textFieldY, textWidth, textHeight), textFieldString, characterLimit);// text field is displaying nothing. This is the user's input field
		GUI.Label (new Rect (rectX, rectY, labelWidth, labelHeight), eneterPassword);// label for the instructions. Can be adjusted. 
		if (textFieldString == passwordNeededToPass)// if the input from the user matches the password that is needed, the player wins and can move on to the next stage
			OpenTheDoor();
		else
			win = false;
	}
	void OpenTheDoor(){
        print("open si Door!");
		door.SetActive (false);
	}
}

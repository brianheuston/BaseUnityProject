using UnityEngine;
using System.Collections;

public class TitleScreenScript : MonoBehaviour {

	void OnGUI()
	{
		const int buttonWidth = 90;
		const int buttonHeight = 60;
		
		// Draw a button to start the game
		if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2),
								(3 * Screen.height / 5) - (buttonHeight / 2),
								buttonWidth, buttonHeight), "Start")) 
		{
			Application.LoadLevel("GameScene");
		} 
		else if (GUI.Button(new Rect(Screen.width / 2 - (buttonWidth / 2),
									   (4 * Screen.height / 5) - (buttonHeight / 2),
									   buttonWidth, buttonHeight), "Quit")) 
		{
			Application.Quit();
		}
	}
}


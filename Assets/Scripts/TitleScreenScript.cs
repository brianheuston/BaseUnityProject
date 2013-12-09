using UnityEngine;
using System.Collections;

public class TitleScreenScript : MonoBehaviour {

	void OnGUI()
	{
		const int buttonWidth = 84;
		const int buttonHeight = 60;
		
		// Draw a button to start the game
		if (
			GUI.Button(
			// Center in X, 2/3 of the height in Y
			new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			"Start!"
			)
			)
		{
			Application.LoadLevel("GameScene");
		}
	}
}


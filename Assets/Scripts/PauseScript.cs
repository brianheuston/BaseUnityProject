using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI() {
		const int buttonWidth = 84;
		const int buttonHeight = 60;

		if (GUI.Button(
			new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			"Continue"
			)
		    )
		{
			Destroy(transform.gameObject.GetComponent<PauseScript>());
		}
		if (GUI.Button(
			new Rect(
			Screen.width / 2 - (buttonWidth / 2),
			(2 * Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			"Quit"
			)
		    )
		{
			Application.LoadLevel("TitleScreen");
		}
	}
}

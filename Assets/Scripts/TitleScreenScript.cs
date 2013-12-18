using UnityEngine;
using System.Collections;

public class TitleScreenScript : MonoBehaviour {
	private int iSelected = 0;
	private string[] arrButtonNames = new string[] { "Start", "Quit" };

	public const int gridWidth = 90;
	public const int gridHeight = 60;

	public const float fMaxJoystickRange = 0.8f;

	void OnGUI()
	{
		iSelected = GUI.SelectionGrid(new Rect(Screen.width / 2 - (gridWidth / 2),
		                                       Screen.height * 3 / 5 - (gridHeight / 2),
		                                       gridWidth, gridHeight), 
		                                       iSelected, arrButtonNames, 1);

		if (GUI.changed) {
			Debug.Log("Selected: " + iSelected);
		}
	}

	void Update() {
		if (Input.GetButtonUp("Up") || Input.GetAxis("Vertical") < -fMaxJoystickRange) {
			iSelected = Mathf.Max(iSelected - 1, 0);
			Debug.Log("Axis: " + Input.GetAxis("Vertical"));
		} else if (Input.GetButtonUp("Down") || Input.GetAxis("Vertical") > fMaxJoystickRange) {
			iSelected = Mathf.Min(iSelected + 1, arrButtonNames.Length - 1);
			Debug.Log("Axis: " + Input.GetAxis("Vertical"));
		} else if (Input.GetButtonUp("Select") || (GUI.changed && Input.GetMouseButtonUp(0)) ||
		           Input.GetButtonUp("Select (Controller)")) {
			ProcessInput();
		} else if (Input.GetButtonUp("Back (Controller)")) {
			QuitGame();
		}
	}

	void LoadGame() {
		Application.LoadLevel("GameScene");
	}

	void QuitGame() {
		Application.Quit();
	}

	void ProcessInput() {
		switch (iSelected) {
			case 0:
				LoadGame();
				break;
			case 1:
				QuitGame();
				break;
			default:
				break;
		}
	}
}


using UnityEngine;
using System.Collections;

public class TitleScreenScript : MonoBehaviour {
	private int iSelected = 0;
	private string[] arrButtonNames = new string[] { "Start", "Quit" };

	public int gridWidth;
	public int gridHeight;

	public const float fMaxJoystickRange = 0.8f;

    void Start() {
        gridWidth = Screen.width / 2;
        gridHeight = Screen.height * 2 / 5;

        Debug.Log("Width: " + Screen.width + ", Height: " + Screen.height);
    }

	void OnGUI()
	{
		iSelected = GUI.SelectionGrid(new Rect(Screen.width / 2 - (gridWidth / 2),
		                                       Screen.height * 3 / 5 - (gridHeight / 2),
		                                       gridWidth, gridHeight), 
		                                       iSelected, arrButtonNames, 1);

		Debug.Log("Initial selection: " + iSelected);
        if (GUI.Button(new Rect(10, 10, 200, 20), "Meet the flashing button")) {
            Debug.Log("You clicked me!");
        }

	}

	void Update() {
		if (Input.GetButtonUp("Up") || Input.GetAxis("Vertical") < -fMaxJoystickRange) {
			iSelected = Mathf.Max(iSelected - 1, 0);
			Debug.Log("Axis: " + Input.GetAxis("Vertical"));
		} else if (Input.GetButtonUp("Down") || Input.GetAxis("Vertical") > fMaxJoystickRange) {
			iSelected = Mathf.Min(iSelected + 1, arrButtonNames.Length - 1);
			Debug.Log("Axis: " + Input.GetAxis("Vertical"));
		} else if (Input.GetButtonUp("Select") || Input.GetButtonUp("Select (Controller)") || 
		           (GUI.changed && (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)))) {
			ProcessInput();
		} else if (Input.GetButtonUp("Back (Controller)")) {
			QuitGame();
		}

        if (GUI.changed) {
            Debug.Log("Selection: " + iSelected);
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


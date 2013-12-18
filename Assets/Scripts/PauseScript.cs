using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {
	private int iSelected = 0;
	private string[] arrButtonNames = new string[] { "Continue", "Quit" };
	
	public const int gridWidth = 90;
	public const int gridHeight = 60;

	private float fOldTimescale = 0.0f;

	public const float fMaxJoystickRange = 0.8f;

	// Use this for initialization
	void Start () {
		fOldTimescale = Time.timeScale;
		Time.timeScale = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp("Up") || Input.GetAxis("Vertical") < -fMaxJoystickRange) {
			iSelected = Mathf.Max(iSelected - 1, 0);
		} else if (Input.GetButtonUp("Down") || Input.GetAxis("Vertical") > fMaxJoystickRange) {
			iSelected = Mathf.Min(iSelected + 1, arrButtonNames.Length - 1);
		} else if (Input.GetButtonUp("Select") || (GUI.changed && Input.GetMouseButtonUp(0)) || 
		           Input.GetButtonUp("Select (Controller)")) {
			ProcessInput();
		} else if (Input.GetButtonUp("Back (Controller)")) {
			ResumeGame();
		}
	}

	void OnDestroy() {
		Time.timeScale = fOldTimescale;
	}

	void OnGUI() {
		iSelected = GUI.SelectionGrid(new Rect(Screen.width / 2 - (gridWidth / 2),
		                                       Screen.height * 3 / 5 - (gridHeight / 2),
		                                       gridWidth, gridHeight), 
		                              		   iSelected, arrButtonNames, 1);
	}

	void ProcessInput() {
		switch (iSelected) {
			case 0:
				ResumeGame();
				break;
			case 1:
				Time.timeScale = fOldTimescale;
				Application.LoadLevel("TitleScreen");
				break;
			default:
				break;
		}
	}

	void ResumeGame() {
		Time.timeScale = fOldTimescale;
		Destroy(transform.gameObject.GetComponent<PauseScript>());
	}
}

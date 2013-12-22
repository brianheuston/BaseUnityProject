using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {
	private int iSelected = 0;
	private string[] arrButtonNames = new string[] { "Restart", "Quit" };
	
	public const int gridWidth = 90;
	public const int gridHeight = 60;
	
	private float fOldTimescale = 0.0f;
	
	public const float fMaxJoystickRange = 0.8f;

	public bool bStopTime = false;
	
	// Use this for initialization
	void Start () {
		PauseTimescale();
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
			// If they hit back on the game over screen, it probably means they
			// want to exit to the title screen.
			Application.LoadLevel("TitleScreen");
		}
	}
	
	void OnDestroy() {
		ResumeTimescale();
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
				RestartGame();
				break;
			case 1:
				ResumeTimescale();
				Application.LoadLevel("TitleScreen");
				break;
			default:
				break;
		}
	}
	
	void RestartGame() {
		ResumeTimescale();
		Destroy(transform.gameObject.GetComponent<GameOverScript>());
		Application.LoadLevel("GameScreen");
	}

	void ResumeTimescale() {
		if (bStopTime) {
			Time.timeScale = fOldTimescale;
		}
	}

	void PauseTimescale() {
		if (bStopTime) {
			fOldTimescale = Time.timeScale;
			Time.timeScale = 0.0f;
		}
	}
}

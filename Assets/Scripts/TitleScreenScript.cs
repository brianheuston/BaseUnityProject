using UnityEngine;
using System.Collections;

public class TitleScreenScript : MonoBehaviour {
	private int iSelected = 0;
	private string[] arrButtonNames = new string[] { "Start", "Quit" };

	public const int gridWidth = 90;
	public const int gridHeight = 60;

	void OnGUI()
	{
		iSelected = GUI.SelectionGrid(new Rect(Screen.width / 2 - (gridWidth / 2),
		                                       Screen.height * 3 / 5 - (gridHeight / 2),
		                                       gridWidth, gridHeight), 
		                                       iSelected, arrButtonNames, 1);
	}

	void Update() {
		if (Input.GetButtonUp("Up")) {
			iSelected = Mathf.Max(iSelected - 1, 0);
		} else if (Input.GetButtonUp("Down")) {
			iSelected = Mathf.Min(iSelected + 1, arrButtonNames.Length - 1);
		} else if (Input.GetButtonUp("Select")) {
			switch (iSelected) {
				case 0:
					LoadGame();
					break;
				case 1:
					Application.Quit();
					break;
				default:
					break;
			}
		}
	}

	void LoadGame() {
		Application.LoadLevel("GameScene");
	}
}


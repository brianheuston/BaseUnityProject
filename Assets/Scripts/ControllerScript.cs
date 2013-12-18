using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonUp("Pause")) {
			if (Time.timeScale == 0.0f) {
				ResumeGame();
			} else {
				PauseGame();
			}
		}
	}

	void ResumeGame() {
		Destroy(transform.gameObject.GetComponent<PauseScript>());
	}

	void PauseGame() {
		transform.gameObject.AddComponent<PauseScript>();
	}
}
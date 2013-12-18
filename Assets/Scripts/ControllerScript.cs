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
				Destroy(transform.gameObject.GetComponent<PauseScript>());
			} else {
				transform.gameObject.AddComponent<PauseScript>();
			}
		}
	}
}
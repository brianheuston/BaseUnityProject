using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {
	private float fOldTimescale = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Pause")) {
			if (Time.timeScale == 0.0f) {
				Time.timeScale = fOldTimescale;
				Destroy(transform.gameObject.GetComponent<PauseScript>());
			} else {
				fOldTimescale = Time.timeScale;
				transform.gameObject.AddComponent<PauseScript>();
				Time.timeScale = 0.0f;
			}
		}
	}
}
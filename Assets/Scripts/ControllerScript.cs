using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			if (transform.gameObject.GetComponent<PauseScript>() != null) {
				Destroy(transform.gameObject.GetComponent<PauseScript>());
			} else {
				transform.gameObject.AddComponent<PauseScript>();
			}
		}
	}
}

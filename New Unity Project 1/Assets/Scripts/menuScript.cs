using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			SceneManager.LoadScene ("Scene1");
		}
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class gameOverScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (Timer ());
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			SceneManager.LoadScene ("MainMenu");
		}
	}

	IEnumerator Timer()
	{
		yield return new WaitForSeconds (7f);
		SceneManager.LoadScene ("MainMenu");
	}
}

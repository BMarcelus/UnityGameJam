using UnityEngine;
using System.Collections;

public class deleteGameObject : MonoBehaviour {

	public Camera cam;
	private float screenWidth;
	private float myWidth = 100;
	
	void Start()
    {
		cam = Camera.main;
		screenWidth = cam.aspect * 2f * cam.orthographicSize;
		myWidth = GetComponent<Renderer> ().bounds.size.x;
	}
		

	void Update()
	{
		if (cam.transform.position.x > transform.position.x + myWidth / 2 + screenWidth / 2) 
		{
			Destroy (this.gameObject);
		}
	}

}

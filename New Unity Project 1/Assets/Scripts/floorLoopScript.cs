using UnityEngine;
using System.Collections;

public class floorLoopScript : MonoBehaviour {

	public Camera cam;
 	private float screenWidth;
	private float myWidth = 100;
	[SerializeField] private int floors = 3;

	void Start ()
    {
        cam = Camera.main;
		screenWidth = cam.aspect * 2f * cam.orthographicSize;
		myWidth = GetComponent<Renderer> ().bounds.size.x;

	}
	
	void Update ()
    {
		screenWidth = cam.aspect * 2f * cam.orthographicSize;
		float width = screenWidth / 2 + myWidth / 2;
		if (cam.transform.position.x > transform.position.x + width) 
		{
			transform.position += new Vector3 (myWidth*floors, 0, 0);

		}

	}

}


using UnityEngine;
using System.Collections;

public class floorLoopScript : MonoBehaviour {

	public Camera camera;
 	private float screenWidth;
	private float myWidth = 100;
	[SerializeField] private int floors=3;

	// Use this for initialization
	void Start () {
		screenWidth = camera.aspect * 2f * camera.orthographicSize;
		myWidth = GetComponent<Renderer> ().bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {
		screenWidth = camera.aspect * 2f * camera.orthographicSize;
		float width = screenWidth / 2 + myWidth / 2;
		if (camera.transform.position.x > transform.position.x + width) 
		{
			transform.position += new Vector3 (myWidth*floors, 0, 0);
		}
	}
}

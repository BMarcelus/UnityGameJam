using UnityEngine;
using System.Collections;

public class positionalSpawn : MonoBehaviour {

	public Camera cam;
	public GameObject item_to_spawn;

	private float screenWidth;
	private Vector3 last_pos;
	[SerializeField] private float distance = 20;

	// Use this for initialization
	void Start () {
		cam = Camera.main;
		screenWidth = cam.aspect * 2f * cam.orthographicSize;
		last_pos = cam.transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (cam.transform.position.x > last_pos.x + distance)
		{
			last_pos = cam.transform.position;
			SpawnItem ();
		}
			
	}

	void SpawnItem()
	{
		Vector3 new_pos = new Vector3(cam.transform.position.x + screenWidth/2, -2, 0);
		Instantiate(item_to_spawn, new_pos, Quaternion.identity);

	}
}

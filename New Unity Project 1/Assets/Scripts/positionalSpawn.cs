using UnityEngine;
using System.Collections;

public class positionalSpawn : MonoBehaviour {

	public Camera cam;
	public GameObject item_to_spawn;
	public GameObject wall_to_spawn;
	public GameObject art_to_spawn;

	private float screenWidth;
	private Vector3 last_pos;
	[SerializeField] private float min_distance = 6;
	[SerializeField] private float max_distance = 20;
	private float distance = 20;

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
			if (Random.Range (0, 10) > 5)
				SpawnItem ();
			else if (Random.Range (0, 10) < 4)
				SpawnWall ();
			else
				SpawnArt ();
			distance = Random.Range (min_distance, max_distance);
		}
			
	}

	void SpawnArt()
	{
		Vector3 new_pos = new Vector3(cam.transform.position.x + screenWidth/2, 3.19f, 0);
		Instantiate(art_to_spawn, new_pos, Quaternion.identity);
	}

	void SpawnWall()
	{
		Vector3 new_pos = new Vector3(cam.transform.position.x + screenWidth/2+1, 6.48f, 0);
		Instantiate(wall_to_spawn, new_pos, Quaternion.identity);
	}

	void SpawnItem()
	{
		Vector3 new_pos = new Vector3(cam.transform.position.x + screenWidth/2+1, -2+Random.Range(0,3)*2, 0);
		Instantiate(item_to_spawn, new_pos, Quaternion.identity);

	}
}

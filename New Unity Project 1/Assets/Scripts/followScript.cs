using UnityEngine;
using System.Collections;

public class followScript : MonoBehaviour {


	public GameObject player;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position = player.transform.position + offset;
		//transform.position.x += (player.transform.position.x - transform.position.x) / 3;
		//transform.position.y += (player.transform.position.y - transform.position.y) / 3;
		//this.transform.position.x = Mathf.Lerp(this.transform.position.x, player.transform.position.x, 0.1f);
		//this.transform.position.y = Mathf.Lerp(this.transform.position.y, player.transform.position.y, 0.1f);
		this.transform.position = new Vector3 (Mathf.Lerp (this.transform.position.x, player.transform.position.x, 0.5f),
			Mathf.Lerp (this.transform.position.y, player.transform.position.y, 0.5f), this.transform.position.z);
	}
}

using UnityEngine;
using System.Collections;

public class crowdScript : MonoBehaviour {

	public GameObject player;
	public float speed = 1; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	void FixedUpdate(){
		this.transform.position += Vector3.right * speed;
	}

}

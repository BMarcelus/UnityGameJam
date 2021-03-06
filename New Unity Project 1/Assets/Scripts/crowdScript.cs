﻿using UnityEngine;
using System.Collections;

public class crowdScript : MonoBehaviour {

	public GameObject Effect_Manager;
	public GameObject player;
	public float speed = 1; 
	public int spawnSpeed;
	private int spawnTimer=0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	void FixedUpdate(){
		this.transform.position += Vector3.right * speed * ((player.transform.position.x-this.transform.position.x)/10);
		this.transform.position += Vector3.right * Mathf.Cos (Time.frameCount*(Mathf.PI/20))/15;

		spawnTimer--;
		if (spawnTimer < 0) {
			spawnTimer = spawnSpeed;
			Effect_Manager.GetComponent<effectManager>().CloudEffect();
		}
	}

}

using UnityEngine;
using System.Collections;

public class paintingScript : MonoBehaviour {

	[SerializeField] Sprite[] sprites;


	// Use this for initialization
	void Start () {
		this.GetComponent<SpriteRenderer>().sprite=sprites[Random.Range(0,sprites.Length-1)];
		this.transform.position += new Vector3 (this.GetComponent<Renderer>().bounds.size.x/2,0,0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

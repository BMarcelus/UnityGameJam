using UnityEngine;
using System.Collections;

public class moveScript : MonoBehaviour {

	Rigidbody2D rb;
	[SerializeField] private float speed = 1;

	void Start () 
	{
		rb = this.GetComponent<Rigidbody2D>();

	}
	
	void Update () 
	{
		
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		//rb.transform.position.x += horizontal * speed;
		rb.transform.position += new Vector3(horizontal*speed, vertical*speed, 0);
	}
}

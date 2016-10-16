using UnityEngine;
using System.Collections;

public class particleScript : MonoBehaviour {

	public Vector3 velocity;
	public int life;

	public int randomAngle;

	void Start()
	{
		velocity = Quaternion.Euler(0,0,Random.Range(-randomAngle, randomAngle)) * velocity;
	}

	void FixedUpdate()
	{
		this.transform.position += velocity;
		life--;
		Color color = GetComponent<SpriteRenderer>().color;
		//color.r--;
		//color.g --;
		//color.b --;
		color.a -= .1f;
		GetComponent<SpriteRenderer>().color = color;
		if (life <= 0)
			Destroy (this.gameObject);
	}
}

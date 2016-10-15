using UnityEngine;
using System.Collections;

public class playerManager : MonoBehaviour {

    Rigidbody2D rb;

    public float run_speed;
    public float jump_force;

    public bool is_jumping = false;
    public bool in_air = false;
	public bool in_slide = false;
	public bool landing = false;
	public float falling=0;

	Animator animator;

	void Start ()
    {
        rb = this.GetComponent<Rigidbody2D>();
		animator = this.GetComponent<Animator> ();
	}
	
	void Update ()
    {
		animator.SetBool ("in_air", is_jumping);
		if (Input.GetKey(KeyCode.W) && !is_jumping && !in_air && !landing)
        {
            is_jumping = true;
            in_air = true;
			animator.SetBool ("in_air", is_jumping);
        }
		if (Input.GetKey (KeyCode.S) && !is_jumping && !in_air) {
			in_slide = true;

		} else {
			in_slide = false;
		}
		animator.SetBool("is_sliding", in_slide);
		if (landing)
			landing = false;

	}

    void FixedUpdate()
    {
		rb.transform.position += (Vector3.right * run_speed * Time.deltaTime);

        if (is_jumping)
        {
			Vector3 vy = (Vector3.up * jump_force * Time.deltaTime);
			transform.position += vy;

        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
		
		if (coll.gameObject.tag == "Ground" && in_air && 
			transform.position.y-GetComponent<BoxCollider2D>().size.y/2>coll.gameObject.transform.position.y)
        {
            is_jumping = false;
            in_air = false;
			animator.SetBool ("in_air", is_jumping);
			landing = true;
        }

    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground" && !in_air && this.transform.position.y > 0)
        {
            in_air = true;

        }

    }

}

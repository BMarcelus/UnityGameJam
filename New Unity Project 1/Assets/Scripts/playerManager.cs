using UnityEngine;
using System.Collections;

public class playerManager : MonoBehaviour {

    Rigidbody2D rb;

    public float run_speed;
    public float jump_force;

    public bool is_jumping = false;
    public bool in_air = false;
	public bool in_slide = false;

	Animator animator;

	void Start ()
    {
        rb = this.GetComponent<Rigidbody2D>();
		animator = this.GetComponent<Animator> ();
	}
	
	void Update ()
    {
	    if (Input.GetKey(KeyCode.W) && !is_jumping && !in_air)
        {
            is_jumping = true;
            in_air = true;

        }
		if (Input.GetKey (KeyCode.S) && !is_jumping && !in_air) {
			//transform.localEulerAngles = new Vector3 (0, 0, 90);
			//if(!in_slide) transform.position += new Vector3(0,-1.4f,0);
			//transform.localScale = new Vector3 (1, 0.5f, 1);
			in_slide = true;

		} else {
			//if(in_slide) transform.position += new Vector3(0,1.4f,0);
			//transform.localScale = new Vector3 (1, 1, 1);
			in_slide = false;
		}
		animator.SetBool("is_sliding", in_slide);
		animator.SetBool ("in_air", in_air);
	}

    void FixedUpdate()
    {
        rb.transform.Translate(Vector2.right * run_speed * Time.deltaTime);

        if (is_jumping)
        {
            rb.transform.Translate(Vector2.up * jump_force * Time.deltaTime);

        }

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ground" && in_air)
        {
            is_jumping = false;
            in_air = false;

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

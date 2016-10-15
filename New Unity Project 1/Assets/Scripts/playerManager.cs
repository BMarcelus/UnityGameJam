using UnityEngine;
using System.Collections;

public class playerManager : MonoBehaviour {

    Rigidbody2D rb;

    public float run_speed;
    public float jump_force;

    public bool is_jumping = false;
    public bool in_air = false;

	void Start ()
    {
        rb = this.GetComponent<Rigidbody2D>();

	}
	
	void Update ()
    {
	    if (Input.GetKey(KeyCode.W) && !is_jumping && !in_air)
        {
            is_jumping = true;
            in_air = true;

        }

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

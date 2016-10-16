﻿using UnityEngine;
using System.Collections;

public class playerManager : MonoBehaviour {

    Rigidbody2D rb;

    public float run_speed;
    public float jump_force;

    public bool is_jumping = false;
    public bool in_air = false;
	public bool in_slide = false;
	public bool landing = false;
	public bool touching = false;
	public bool art_col = false;

	public int points = 0;

	Animator animator;

	void Start ()
    {
        rb = this.GetComponent<Rigidbody2D>();
		animator = this.GetComponent<Animator> ();
	}
	
	void Update ()
    {
		animator.SetBool ("in_air", is_jumping);
		if (Input.GetKey(KeyCode.W) && !is_jumping && !in_air && !landing && !touching)
        {
            is_jumping = true;
            in_air = true;
			animator.SetBool ("in_air", is_jumping);
        }
		if (Input.GetKey (KeyCode.S) && !is_jumping && !in_air &&!touching ) {
			in_slide = true;

		} else {
			in_slide = false;
		}
		animator.SetBool("is_sliding", in_slide);
		if (landing)
			landing = false;

		bool touch = (Input.GetKey (KeyCode.Space) && !is_jumping && !in_air);
		if(!touching && touch)
		{
			BeginTouch ();
		}



	}

	void GetPoint()
	{
		points++;
	}

	void BeginTouch()
	{
		if (art_col)
		{
			GetPoint ();
		}
		animator.SetBool ("touching", true);
		StartCoroutine (TouchStoping());

	}

	IEnumerator TouchStoping()
	{
		touching = true;
		yield return new WaitForSeconds(0.75f);
		touching = false;
		animator.SetBool ("touching", false);
	}


    void FixedUpdate()
    {
		if(!touching)
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

	void OnTriggerEnter2D(Collider2D other)
	{
		art_col = true;
		if (other.gameObject.tag == "Art" && !in_air && !in_slide) {
			//animator.SetBool ("touching", true);
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		art_col = false;
		if (other.gameObject.tag == "Art") {
			//animator.SetBool ("touching", false);
		}
	}

}

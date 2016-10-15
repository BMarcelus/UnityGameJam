using UnityEngine;
using System.Collections;

public class playerManager : MonoBehaviour {

    Rigidbody2D rb;

    public float run_speed;
    public float jump_force;

    bool is_jumping = false;

	void Start ()
    {
        rb = this.GetComponent<Rigidbody2D>();

	}
	
	void Update ()
    {
	    if (Input.GetKey(KeyCode.W) && !is_jumping)
        {
            StartCoroutine(JumpWait());

        }

	}

    void FixedUpdate()
    {
        rb.transform.Translate(Vector2.right * run_speed * Time.deltaTime);

        if (is_jumping)
        {
            rb.transform.Translate(Vector3.up * jump_force * Time.deltaTime);

        }

    }

    IEnumerator JumpWait()
    {
        is_jumping = true;
        yield return new WaitForSeconds(1);
        is_jumping = false;

    }

}

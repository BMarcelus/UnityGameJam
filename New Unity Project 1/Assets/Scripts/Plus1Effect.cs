using UnityEngine;
using System.Collections;

public class Plus1Effect : MonoBehaviour {

    public float add_y;
    public float end_y;

    void Start()
    {
        end_y = transform.position.y + end_y;

    }

	void FixedUpdate ()
    {
	    if (transform.position.y < end_y)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + add_y);

            if (transform.position.y > end_y / 2)
            {
                Color transparent = GetComponent<SpriteRenderer>().color;
                transparent.a -= add_y;
                GetComponent<SpriteRenderer>().color = transparent;

            }

        }
        else
        {
            Destroy(this.gameObject);

        }

	}

}

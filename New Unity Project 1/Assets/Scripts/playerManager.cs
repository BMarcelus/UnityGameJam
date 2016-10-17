using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class playerManager : MonoBehaviour {

	public GameObject cam;
    public GameObject Effect_Manager;
	public AudioSource audi;

	public GameObject fadeOut;

	public AudioClip jumpSound;
	public AudioClip dieSound;
	public AudioClip slideSound;

    Rigidbody2D rb;

    public float run_speed;
    public float jump_force;

    public bool is_jumping = false;
    public bool in_air = false;
	public bool in_slide = false;
	public bool landing = false;
	public bool touching = false;
	public bool art_col = false;
	public bool dead = false;

	private bool slide_held = false;

	private IEnumerator slideRoutine;

	public int points = 0;
	private Vector3 stopTarget;

	Animator animator;

	void Start ()
    {
        rb = this.GetComponent<Rigidbody2D>();
		animator = this.GetComponent<Animator> ();
		audi = GetComponent<AudioSource>();
	}
	
	void Update ()
    {
		
		animator.SetBool ("in_air", is_jumping);
		if ( (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow)) && !is_jumping && !in_air && !landing && !touching &&!dead)
        {
			audi.Stop ();
			audi.PlayOneShot (jumpSound, 1);
            is_jumping = true;
            in_air = true;
			animator.SetBool ("in_air", is_jumping);
        }

		bool slide = ( (Input.GetKey (KeyCode.S)||Input.GetKey(KeyCode.DownArrow)) && !is_jumping && !in_air && !touching);
		if (slide && !slide_held && !in_slide && !dead) 
		{
			StartSlide ();
		}
		if (slide_held && !slide) {
			//animator.SetBool ("is_sliding", false);
			//StopCoroutine (slideRoutine);
		}
		slide_held = slide;

		if (landing)
			landing = false;

		bool touch = (Input.GetKey (KeyCode.Space) && !is_jumping && !in_air && !in_slide);
		if(!touching && touch)
		{
			BeginTouch ();
		}



	}

	void StartSlide()
	{
		slideRoutine = SlideStopping ();
		StartCoroutine (slideRoutine);
	}

	IEnumerator SlideStopping()
	{
		in_slide = true;
		animator.SetBool ("is_sliding", true);
		audi.PlayOneShot (slideSound, 1);
		yield return new WaitForSeconds(0.5f);
		animator.SetBool ("is_sliding", false);
		in_slide = false;
	}


	void GetPoint()
	{
		points++;
        Effect_Manager.GetComponent<effectManager>().PointEffect();

	}

	void BeginTouch()
	{
		
		animator.SetBool ("touching", true);
		StartCoroutine (TouchStoping());
		stopTarget = this.transform.position + Vector3.right * 2;
	}

	IEnumerator TouchStoping()
	{
		touching = true;
		yield return new WaitForSeconds(0.25f);
		if (art_col) {
			GetPoint ();
			art_col = false;
		}
		yield return new WaitForSeconds(0.50f);
		touching = false;
		animator.SetBool ("touching", false);

	}


    void FixedUpdate()
    {
		if (dead) {
			Color color = fadeOut.GetComponent<SpriteRenderer> ().color;
			color.a+=.01f;
			fadeOut.GetComponent<SpriteRenderer> ().color = color;
		}else
		{
			
			if (touching) {
				transform.position = Vector3.Lerp (transform.position, stopTarget, 0.1f);
			} else {
				rb.transform.position += (Vector3.right * run_speed * Time.deltaTime);
			}

		}
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
		
		if (other.gameObject.tag == "Art") {
			art_col = true;
		} else if (other.gameObject.tag == "Crowd" && !dead) {
			GameOver ();
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag == "Art") {
			art_col = false;
		}
	}


	void GameOver()
	{
		cam.GetComponent<AudioSource> ().Stop ();

		dead=true;
		animator.SetBool ("dead", true);
		StartCoroutine (GameOverScene());
	}
		
	IEnumerator GameOverScene()
	{
		//yield return new WaitForSeconds (1f);
		audi.PlayOneShot (dieSound, 1);
		//yield return new WaitForSeconds(7.5f);
		//Application.LoadLevel ("GameOver");
		//SceneManager.LoadScene ("GameOver");
		yield return new WaitForSeconds(5.5f);
		SceneManager.LoadScene ("GameOver");
	}
}

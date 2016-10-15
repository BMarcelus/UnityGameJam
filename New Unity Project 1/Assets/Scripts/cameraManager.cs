using UnityEngine;
using System.Collections;

public class cameraManager : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	void Start()
	{
		offset = transform.position-player.transform.position;
	}

    void FixedUpdate()
    {
		Vector3 target = player.transform.position+offset;
		target.y = offset.y;
		this.transform.position = Vector3.Lerp(transform.position, target, 0.25f);

    }
}

using UnityEngine;
using System.Collections;

public class cameraManager : MonoBehaviour {

	public GameObject player;

    void FixedUpdate()
    {
        this.transform.position = Vector3.Lerp(transform.position, player.transform.position, 0.25f) + new Vector3(1, 0, -10);

    }
}

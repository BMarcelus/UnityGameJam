using UnityEngine;
using System.Collections;

public class effectManager : MonoBehaviour {

    public GameObject player;

    public GameObject plus_1;

	public GameObject cloud;

	public GameObject crowd;

    public void PointEffect()
    {
        Vector3 temp_vec = new Vector3(0, 3, 0) + player.transform.position;
        Instantiate(plus_1, temp_vec, Quaternion.identity);

    }


	public void CloudEffect()
	{
		Vector3 temp_vec = crowd.transform.position+new Vector3(1, 3, 0);
		Instantiate (cloud, temp_vec, Quaternion.identity);
	}


}

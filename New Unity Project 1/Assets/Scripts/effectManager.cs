using UnityEngine;
using System.Collections;

public class effectManager : MonoBehaviour {

    public GameObject player;

    public GameObject plus_1;

    public void PointEffect()
    {
        Vector3 temp_vec = new Vector3(0, 3, 0) + player.transform.position;
        Instantiate(plus_1, temp_vec, Quaternion.identity);

    }

}

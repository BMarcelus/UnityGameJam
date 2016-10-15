using UnityEngine;
using System.Collections;

public class deleteGameObject : MonoBehaviour {

    public int secs_until_delete;
	
	void Start()
    {
        StartCoroutine(Countdown());
	}

    IEnumerator Countdown()
    {
        yield return new WaitForSeconds(secs_until_delete);
        Destroy(this.gameObject);

    }

}

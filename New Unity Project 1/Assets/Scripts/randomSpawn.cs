using UnityEngine;
using System.Collections;

public class randomSpawn : MonoBehaviour {

    public Camera cam;
    public GameObject item_to_spawn;

    bool can_spawn = true;

    public int min_spawn_sec;
    public int max_spawn_sec;

	void Start ()
    {
        cam = Camera.main;

	}
	
	void Update ()
    {
	   if (can_spawn)
        {
            StartCoroutine(ItemCooldown());

        } 

	}

    void SpawnItem()
    {
        Vector3 new_pos = new Vector3(cam.transform.position.x + 7.5f, -2, 0);
        Instantiate(item_to_spawn, new_pos, Quaternion.identity);

    }

    IEnumerator ItemCooldown()
    {
        can_spawn = false;
        SpawnItem();
        yield return new WaitForSeconds(Random.Range(min_spawn_sec, max_spawn_sec));
        can_spawn = true;

    }

}

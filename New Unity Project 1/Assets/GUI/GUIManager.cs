using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

    public Text score_text_object;
    public GameObject player_object;

    string score_text = "Score: ";

	void Start ()
    {
        score_text_object.text = score_text + "0";

	}
	
	void Update ()
    {
        score_text_object.text = score_text + player_object.GetComponent<playerManager>().points;

    }

}

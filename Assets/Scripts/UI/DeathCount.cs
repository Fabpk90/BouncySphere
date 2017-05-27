using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Scripts;

public class DeathCount : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GetComponent<Text>().text = "Death: " + PlayerData.deathCount;

	}
	
	// Update is called once per frame
	void Update () {

        GetComponent<Text>().text = "Death: " + PlayerData.deathCount;
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	// Update is called once per frame
	void Update () {

        GetComponent<Text>().text = "" + ((System.Math.Round(PlayerMovement.getTimer() * 100.0)) / 100.0).ToString("0.00");

    }
}

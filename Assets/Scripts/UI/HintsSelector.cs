using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintsSelector : MonoBehaviour {

    public string[] Hints;

    private int indexDialog = 0;

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = Hints[indexDialog];
    }

    public void nextDialog()
    {
        if (indexDialog + 1 < Hints.Length)
        {
            indexDialog++;
            GetComponent<Text>().text = Hints[indexDialog];
        }
        else
            GameManager.loadLevel("Level1", true);
        
    }

}

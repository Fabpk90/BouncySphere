using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintsSelector : MonoBehaviour {

    public string[] HintsDesktop;
    public string[] HintsMobile;

    private int indexDialog = 0;

    public GameObject BtnDialogText;

	// Use this for initialization
	void Start () {
        if(Application.platform == RuntimePlatform.Android)
            GetComponent<Text>().text = HintsMobile[indexDialog];
        else
            GetComponent<Text>().text = HintsDesktop[indexDialog];

        if (indexDialog + 1 >= HintsMobile.Length)
        {
            BtnDialogText.GetComponent<Text>().text = "Play";
        }
    }

    public void nextDialog()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (indexDialog + 1 < HintsMobile.Length)
            {
                indexDialog++;
                GetComponent<Text>().text = HintsMobile[indexDialog];
                if (indexDialog + 1 >= HintsMobile.Length)
                {
                    BtnDialogText.GetComponent<Text>().text = "Play";
                }
            }
            else
                GameManager.loadLevel("Level1");
        }
        else
        {
            if (indexDialog + 1 < HintsDesktop.Length)
            {
                indexDialog++;
                GetComponent<Text>().text = HintsDesktop[indexDialog];
            }
            else
                GameManager.loadLevel("Level1");
        }
           
        
    }

}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Scripts;
using System.IO;

public class LevelMenuCreator : MonoBehaviour
{

    public GUIStyle buttonStyle;

    void onGui()
    {
        GUI.Button(new Rect(100, 100, 50, 50), "Level1", buttonStyle);

        //GUI.Button()

        Debug.Log("qsdqsd");
    }
    
}


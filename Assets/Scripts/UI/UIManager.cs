using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

    public static GameObject self;

    private void OnEnable()
    {
        UIManager.self = gameObject;
    }
}

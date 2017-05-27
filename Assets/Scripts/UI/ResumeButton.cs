using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour {


    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(clicked);
    }

    private void clicked()
    {
        GameManager.StartTime();
        ((Component) gameObject.GetComponentInParent<Canvas>()).gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour {


    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(clicked);
    }

    private void OnEnable()
    {
        if (GameManager.playerMovement.Dead)
        {
            GetComponentInChildren<Text>().text = "Respawn";
        } 
    }

    private void clicked()
    {
        GameManager.StartTime();

        GameManager.playerMovement.TogglePauseMenu();

        if (GameManager.playerMovement.Dead)
        {
            GameManager.playerMovement.Respawn();
        }
    }
}

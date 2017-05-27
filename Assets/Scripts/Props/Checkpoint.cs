using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {
    public static int id = 0;
    private int PortalId;

    public bool IsActivated;

    public AudioClip saveSound;

    void Start()
    {
        PortalId = id;
        id++;

        IsActivated = false;

        transform.name = "Checkpoint";
    }

    public int getId()
    {
        return PortalId;
    }

    public void checkpointPassed()
    {
        IsActivated = true;

        GetComponent<Renderer>().material.color = Color.green;
        GetComponentInChildren<Flag>().activateFlag(true);

        GetComponent<AudioSource>().PlayOneShot(saveSound);
    }
}

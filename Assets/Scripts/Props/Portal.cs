using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {
    public Transform destination = null;

    public AudioClip tpSound;

    void Start()
    {
        transform.name = "Portal";
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().PlayOneShot(tpSound); 
    }


}

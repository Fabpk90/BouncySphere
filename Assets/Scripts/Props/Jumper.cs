using UnityEngine;
using System.Collections;

public class Jumper : MonoBehaviour {
    public float jumpForce = 0;

    public AudioClip jumpSound;

    void Start()
    {
        transform.name = "Jumper";
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<AudioSource>().PlayOneShot(jumpSound);
    }


}

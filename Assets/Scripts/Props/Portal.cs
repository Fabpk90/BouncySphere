using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {
    public Transform destination = null;

    void Start()
    {
        transform.name = "Portal";
    }
}

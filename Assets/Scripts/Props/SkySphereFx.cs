using UnityEngine;
using System.Collections;

public class SkySphereFx : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 0, 0.01f));
	}
}

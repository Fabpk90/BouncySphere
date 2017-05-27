using UnityEngine;
using System.Collections;

public class Booster : MonoBehaviour {

    public Vector3 boostVector = new Vector3(0, 0, 0);

    void Start()
    {
        transform.name = "Booster";
    }

	public void setForce(Vector3 newForce)
    {
        boostVector = newForce;
    }

    public Vector3 getVectorForce()
    {
        return boostVector;
    }
}

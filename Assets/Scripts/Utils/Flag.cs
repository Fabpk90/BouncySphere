using UnityEngine;
using System.Collections;

public class Flag : MonoBehaviour {
    private bool isAnimated = false;
    private float yPositionStart;

    void Start()
    {
        yPositionStart = transform.position.y;
    }


    void Update()
    {
        if(isAnimated)
        {
            if (transform.position.y < yPositionStart + 2.0f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime, transform.position.z);
            }
            else
                enabled = false;// stops update
        }
    }

    public void activateFlag(bool isAnimated)
    {
        this.isAnimated = isAnimated;

        //pops the flag
        GetComponent<CapsuleCollider>().enabled = true;
        GetComponent<MeshRenderer>().enabled = true;
    }


    public void deactivateFlag()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<CapsuleCollider>().enabled = false;
    }
}

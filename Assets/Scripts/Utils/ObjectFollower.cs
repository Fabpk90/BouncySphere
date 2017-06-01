using UnityEngine;
using System.Collections;

public class ObjectFollower : MonoBehaviour {

    public GameObject ObjectToFollow = null;

    public Vector3 DistanceFromObject = new Vector3(0, 5, -15);
    public Vector3 Rotation;

    //used for storing the distance from the object
    Vector3 newPos = new Vector3();

    // Use this for initialization
    void Start () {

        if (ObjectToFollow == null)
            Debug.LogError("Set a proper object to follow!");

        transform.position = ObjectToFollow.transform.position;
        transform.Rotate(Rotation);

        calculateDistance();

	}
	
	// Update is called once per frame
	void Update () {
        calculateDistance();
    }

    private void calculateDistance()
    {
        if (DistanceFromObject.x != 0)
            newPos.x = ObjectToFollow.transform.position.x + DistanceFromObject.x;           
        else
            newPos.x = ObjectToFollow.transform.position.x;

        if (DistanceFromObject.y != 0)
            newPos.y = ObjectToFollow.transform.position.y + DistanceFromObject.y;             
        else
            newPos.y = ObjectToFollow.transform.position.y;

        if (DistanceFromObject.z != 0)
            newPos.z = ObjectToFollow.transform.position.z + DistanceFromObject.z;                               
        else
            newPos.z = ObjectToFollow.transform.position.z;

        transform.position = newPos;
    }
}

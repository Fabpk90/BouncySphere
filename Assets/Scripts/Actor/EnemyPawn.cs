using UnityEngine;
using System.Collections;

public class EnemyPawn : MonoBehaviour
{
    public Transform[] patrolPoint;
    public float moveSpeed;

    private int currentPoint;

	// Use this for initialization
	void Start ()
    {
        transform.position = patrolPoint[0].position;
        currentPoint = 0;

        transform.name = "Enemy";
    }

    // Update is called once per frame
    void Update()
    {
      
        if (transform.position == patrolPoint[currentPoint].position)
        {
            currentPoint = (currentPoint + 1) % patrolPoint.Length;
        }    

        transform.position = Vector3.MoveTowards(transform.position, patrolPoint[currentPoint].position, moveSpeed * Time.deltaTime);
    }
}

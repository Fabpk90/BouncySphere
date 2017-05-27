using Assets.Scripts;
using System.Diagnostics;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int moveSpeed = 100;
    public int maxSpeed = 600;

    public int multiplySpeed = 100;
    
    public GameObject deathParticles;//particle spawn durig the death
    public AudioClip deathSound; //sound played at death
    public static Vector3 checkpoint;//store the position of the last checkpoint reached

    private Vector3 input;//used as a force impulse using user's input

    public static bool isCheckpointing = false;

    private static float timer = 0;

    public GameObject PauseMenu;

    // Use this for initialization
    void Start()
    {
        checkpoint = transform.position;

        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.fixedDeltaTime;

        if (transform.position.y <= -2)
            Die();

        //open up the menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu.SetActive(!PauseMenu.activeSelf);

            //menu opened
            if (PauseMenu.activeSelf)
            {
                GameManager.StopTime();
            }
            else
            {
                GameManager.StartTime();
            }

           

        }


        if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
            {
                input = new Vector3(0, 0, 0);

#if UNITY_STANDALONE

                if (Input.GetAxisRaw("Horizontal") > 0)//goes to the right
                    goRight();
                else if (Input.GetAxisRaw("Horizontal") < 0)//goes to the left
                    goLeft();
                if (Input.GetAxisRaw("Vertical") > 0)
                    goToward();
                else if (Input.GetAxisRaw("Vertical") < 0)
                    goBackward();
#endif

#if UNITY_ANDROID
    
                //then checkAndLoadLevel the direction of the phone
                if (Input.touches[0].deltaPosition.x > 0)//going to the right
                    goRight();
                else if (Input.touches[0].deltaPosition.x< 0)//going to the left
                    goLeft();

                //checking if the ball need to go toward/inward
                if (Input.touches[0].deltaPosition.y > 0)
                    goToward();
                else if (Input.touches[0].deltaPosition.y< 0)
                    goBackward();
#endif

                GetComponent<Rigidbody>().AddForce(input);
            }

}

    private static void SaveAndExit()
    {
        // FileManager.Save(PlayerData.player, typeof(PlayerData), "playerData");
        PlayerData.Save();
        Application.Quit();
    }

    private void OnApplicationPause(bool pause)
    {
        PlayerData.Save();
    }

    /* [Conditional("UNITY_ANDROID")]
     private void HandlePhoneTouches()
     {

     }*/

    private void OnCollisionEnter(Collision Object)
    {
        //the player has touched an enemy
        if(Object.transform.name == "Enemy")
        {
            Die();
        }

        //the player collides with the goal point
        else if (Object.transform.name == "Goal")
        {     
            GameManager.completeLevel(true);
        }

        //the player takes a boost
        else if(Object.transform.name == "Booster")
        {
            GetComponent<Rigidbody>().AddForce(Object.gameObject.GetComponent<Booster>().getVectorForce());
        }

        //the player has touched a jumper
        else if(Object.transform.name == "Jumper")
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, Object.gameObject.GetComponent<Jumper>().jumpForce, 0)); 
        }

        //the player takes a portal
        else if(Object.transform.name == "Portal")
        {
            if(Object.collider.GetComponent<Portal>().destination!= null)
                transform.position = Object.collider.GetComponent<Portal>().destination.position;
        }

        //the player its a checkpoont
        else if(Object.transform.name == "Checkpoint" )
        {
            checkpoint = Object.transform.position;
            isCheckpointing = true;

            if (!Object.collider.GetComponent<Checkpoint>().IsActivated)
                Object.collider.GetComponent<Checkpoint>().checkpointPassed();

            //System.GC.Collect();
        }
    }

    private void goRight()
    {
        input.x = (moveSpeed * multiplySpeed) * Time.deltaTime;
    }

    private void goLeft()
    {
        input.x = -((moveSpeed * multiplySpeed) * Time.deltaTime);
    }

    private void goToward()
    {
        input.z = (moveSpeed * multiplySpeed) * Time.deltaTime;
    }

    private void goBackward()
    {
        input.z = -((moveSpeed * multiplySpeed) * Time.deltaTime);
    }

    private void Die()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        GetComponent<AudioSource>().PlayOneShot(deathSound, 10); // boom

        //using another object instead of set() because it seems to work this way...
        Vector3 newPos = checkpoint;
        newPos.y += 1;    

        //stopping the forces applied after the death
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        GetComponent<PlayerData>().Die();

        transform.position = newPos;
    }

    public static float getTimer()
    {
        return timer;
    }
}

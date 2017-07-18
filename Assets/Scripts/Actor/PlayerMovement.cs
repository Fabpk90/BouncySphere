using Assets.Scripts;
using UnityEngine.UI;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public int moveSpeed = 100;
    public int maxSpeed = 600;

    public int multiplySpeed = 100;
    
    public GameObject deathParticles;//particle spawn durig the death
    public AudioClip deathSound; //sound played at death

    public static Vector3 checkpoint;//store the position of the last checkpoint reached

    private Vector3 movementVector;//used as a force impulse using user's input

    private static float timer = 0;

    public bool Dead = false;

    public GameObject PauseMenu;
#if UNITY_ANDROID
    private MonoBehaviour Joypad;
#endif
    // Use this for initialization
    void Start()
    {
        GameManager.playerMovement = this;

        checkpoint = transform.position;

        timer = 0.0f;

#if UNITY_ANDROID
        foreach(Transform child in UIManager.self.transform)
        {
            if (child.name == "MobileJoystick")
                Joypad = child.GetComponent<MonoBehaviour>();
        }
#endif

        /*
         bannerView = new BannerView("ca-app-pub-5899990337622125~6806158694", AdSize.SmartBanner, AdPosition.Top);
         // Create an empty ad request.
         AdRequest request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).Build();
         // Load the banner with the request.
         bannerView.LoadAd(request);
         bannerView.Show();*/
    }

    // Update is called once per frame
    void Update()
    {       
        //open up the menu
        if (Input.GetKeyDown(KeyCode.Escape) && !Dead)
        {
            TogglePauseMenu();
        }

        if (!PauseMenu.activeSelf && !Dead)
        {
            if (transform.position.y <= -2)
                Die();

            timer += Time.fixedDeltaTime;

            movementVector = new Vector3(0, 0, 0);
#if UNITY_STANDALONE
            if (Input.GetAxisRaw("Horizontal") > 0)//goes to the right
                goRight();
            else if (Input.GetAxisRaw("Horizontal") < 0)//goes to the left
                goLeft();
            if (Input.GetAxisRaw("Vertical") > 0)
                goToward();
            else if (Input.GetAxisRaw("Vertical") < 0)
                goBackward();

            if(padController.InputDirection.x > 0)
            {
                goRight(padController.InputDirection.x);
            }
            else if (padController.InputDirection.x < 0)
            {
                goLeft();
            }

#endif

#if UNITY_ANDROID
            /*if ((Input.touches[0].deltaPosition.x ) > 0)//going to the right
                goRight();
            else if ((Input.touches[0].deltaPosition.x ) < 0)//going to the left
                goLeft();

            //checking if the ball need to go toward/inward
            if ((Input.touches[0].deltaPosition.y) > 0)
                goToward();
            else if (Input.touches[0].deltaPosition.y < 0)
                goBackward(); */

            if (CrossPlatformInputManager.GetAxis("Horizontal") > 0)//goes to the right
                goRight(CrossPlatformInputManager.GetAxis("Horizontal"));

            else if (CrossPlatformInputManager.GetAxis("Horizontal") < 0)//goes to the left
                goLeft(CrossPlatformInputManager.GetAxis("Horizontal"));

            if (CrossPlatformInputManager.GetAxis("Vertical") > 0)
                goToward(CrossPlatformInputManager.GetAxis("Vertical"));

            else if (CrossPlatformInputManager.GetAxis("Vertical") < 0)
                goBackward(CrossPlatformInputManager.GetAxis("Vertical"));
#endif
            GetComponent<Rigidbody>().AddForce(movementVector);
            }
    }

   

    public void TogglePauseMenu()
    {
        PauseMenu.SetActive(!PauseMenu.activeSelf);

#if UNITY_ANDROID
        Joypad.gameObject.GetComponent<Image>().enabled = !Joypad.gameObject.GetComponent<Image>().enabled;
#endif
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
            {
                transform.position = Object.collider.GetComponent<Portal>().destination.position;
            }   
        }

        //the player hits a checkpoont
        else if(Object.transform.name == "Checkpoint")
        {
            checkpoint = Object.transform.position;

            if (!Object.collider.GetComponent<Checkpoint>().IsActivated)
                Object.collider.GetComponent<Checkpoint>().checkpointPassed();
        }
    }

    private void goRight()
    {
        movementVector.x = (moveSpeed * multiplySpeed) * Time.deltaTime;
    }

    private void goRight(float x)
    {
        movementVector.x = (moveSpeed * multiplySpeed * x) * Time.deltaTime;
    }

    private void goLeft()
    {
        movementVector.x = -((moveSpeed * multiplySpeed) * Time.deltaTime);
    }

    private void goLeft(float x)
    {
        movementVector.x = -((moveSpeed * multiplySpeed * -x) * Time.deltaTime);
        
    }

    private void goToward(float v)
    {
        movementVector.z = (moveSpeed * multiplySpeed * v) * Time.deltaTime;
    }

    private void goToward()
    {
        movementVector.z = (moveSpeed * multiplySpeed) * Time.deltaTime;
    }

    private void goBackward()
    {
        movementVector.z = -((moveSpeed * multiplySpeed) * Time.deltaTime);
    }

    private void goBackward(float v)
    {
        movementVector.z = -((moveSpeed * multiplySpeed * -v) * Time.deltaTime);
    }

    private void Die()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        GetComponent<AudioSource>().PlayOneShot(deathSound, 10); // boom

        //stopping the forces applied after the death
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        GetComponent<PlayerData>().Die();

        Dead = true;

        TogglePauseMenu();
    }

    public void Respawn()
    {
        Vector3 newPos = checkpoint;
        newPos.y += 1;

        //get to the checkpoint
        transform.position = newPos;

        Dead = false;
    }

    public static float getTimer()
    {
        return timer;
    }

}
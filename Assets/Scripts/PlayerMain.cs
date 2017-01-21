using UnityEngine;
using System.Collections;

public class PlayerMain : MonoBehaviour
{
    //Variables
    public float playersCurrentSpeed = 0;
    public float playersCurrentStamina = 100;
    float playerMacStamina = 100;
    public int playerLives = 3;
    public int playerObjectCount = 0;
    public int playerScore = 0;
    public float originalRange;

    //Unity references
    Rigidbody2D playerRigidBody;
    Camera playersGameCamera;
    public Light lt;


    // Use this for initialization
    void Start ()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        playersGameCamera = FindObjectOfType<Camera>();

        lt = GetComponent<Light>();
        originalRange = lt.range;

    }
	void Update ()
    {
        PlayerMovement();
	}
    void FixedUpdate()
    {
        //PlayerMovement();
    }

    void PlayerMovement()
    {

        //Getting the input Axis for the player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        

        Vector2 playerMovement = new Vector2(horizontal, vertical);
        playerRigidBody.velocity = playerMovement * playersCurrentSpeed;

        if (Input.GetKeyDown(KeyCode.E) && (Input.GetButtonDown("Vertical") || Input.GetButtonDown("Horizontal")))
        {
            Debug.Log("I am sneaking");
            playersCurrentSpeed = 1;
            
        }
        else if (Input.GetButtonDown("Vertical") || Input.GetButtonDown("Horizontal") || (Input.GetButtonDown("Vertical") && Input.GetButtonDown("Horizontal")))
        {
            Debug.Log("Play footsteps");
            playersCurrentSpeed = 4;
            lt.range = 50;
        }
        else if (Input.GetButtonUp("Vertical") || Input.GetButtonUp("Horizontal"))
        {
            Debug.Log("Don't play footsteps");
            playersCurrentSpeed = 0;
            lt.range = 4;
        }
    }
}
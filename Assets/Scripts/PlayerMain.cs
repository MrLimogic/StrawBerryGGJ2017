using UnityEngine;
using System.Collections;

public class PlayerMain : MonoBehaviour
{
    //Variables
    public float playerMovementSpeed = 4;

    public float playerCurrentStamina = 100;
    public float stepSoundWaveSize;

   

    //Unity references
    Rigidbody playerRigidBody;
    Camera playersGameCamera;


    // Use this for initialization
    void Start ()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playersGameCamera = FindObjectOfType<Camera>();
        StartCoroutine(StaminaWait());
    }

    IEnumerator StaminaWait()
    {
        while (true)
        {
            Debug.Log("Waited");
            Debug.Log("Current stamina number is: " + playerCurrentStamina);
            if (Input.GetButtonDown("Dash") && playerCurrentStamina != 0)
            {
                playerCurrentStamina--;
            }

            yield return new WaitForSeconds(10f);

            Debug.Log("Did it again");
        }
    }

	// Update is called once per frame
	void Update ()
    {
        PlayerMovement();
        PlayerUpdate();
	}
    void FixedUpdate()
    {

    }

    void PlayerUpdate()
    {
        //Used to update information on the player or play something the player consistantly emits every game tick
    }

    void PlayerMovement()
    {
        //Getting the input Axis for the player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 playerMovement = new Vector3(horizontal, vertical, 0);
        playerRigidBody.velocity = playerMovement * playerMovementSpeed;

        if (Input.GetButtonDown("Dash"))
        {
            playerMovementSpeed += 4;
        }
        if (Input.GetButtonUp("Dash"))
        {
            playerMovementSpeed -= 4;
        }
     }
    

    void EmitSound()
    {
        //Emit heavy breathing, walking, or running sounds from the player
    }

    void walkingOnConcrete()
    {
        //use IEnumerator to wait between playing footsteps
    }
}

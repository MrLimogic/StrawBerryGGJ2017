using UnityEngine;
using System.Collections;

public class PlayerMain : MonoBehaviour
{
    //Variables
    public float playerMovementSpeed = 4f;

    public float playerCurrentStamina = 10f;
    public float stepSoundWaveSize;

    bool isSneaking = false;
    bool isWalking = false;
    bool isSprinting = false;

    //Unity references
    Rigidbody playerRigidBody;
    Camera playersGameCamera;


    // Use this for initialization
    void Start ()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        playersGameCamera = FindObjectOfType<Camera>();

        StartCoroutine(StaminaWait());
        StartCoroutine(ConcreteSneak());
        StartCoroutine(ConcreteWalk());
        StartCoroutine(ConcreteSprint());
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
        //
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

        if (Input.GetButtonDown("Sprint"))
        {
            playerMovementSpeed += 4;
            isSprinting = true;
        }
        if (Input.GetButtonUp("Sprint"))
        {
            playerMovementSpeed -= 4;
            isSprinting = false;
        }
        if (Input.GetButtonDown("Up") || Input.GetButtonDown("Down") || Input.GetButtonDown("Left") || Input.GetButtonDown("Right") && Input.GetButtonUp("Sprint"))
        {
            isWalking = true;
        }
        if (Input.GetButtonUp("Up") && Input.GetButtonUp("Down") && Input.GetButtonUp("Left") && Input.GetButtonUp("Right"))
        {
            isWalking = false;
        }
    }

    void EmitSound()
    { 
        //Emit heavy breathing, walking, or running sounds from the player
    }

    IEnumerator ConcreteSneak()
    {
        while (isSneaking == true)
        {
            //play walk sound 1
            Debug.Log("Playing Sneak sound 1");
            yield return new WaitForSeconds(1f);
            //play walk sound 2
            Debug.Log("Playing Sneak sound 2");
        }
    }
    IEnumerator ConcreteWalk()
    {
        while (isWalking == true)
        {
            //play walk sound 1
            Debug.Log("Playing walk sound 1");
            yield return new WaitForSeconds(1f);
            //play walk sound 2
            Debug.Log("Playing walk sound 2");
        }
    }
    IEnumerator ConcreteSprint()
    {
        while (isSprinting == true)
        {
            //play walk sound 1
            Debug.Log("Playing Sprint sound 1");
            yield return new WaitForSeconds(1f);
            //play walk sound 2
            Debug.Log("Playing Sprint sound 2");
        }
    }
}

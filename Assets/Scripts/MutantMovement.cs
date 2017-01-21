using UnityEngine;
using System.Collections;


public class MutantMovement : MonoBehaviour {

    public Transform[] points;
    private int destinationPoint;
   
    private float speed = 5f;

    private GameObject player;

    private bool seenPlayer;

    private float distance;

    // Use this for initialization
    void Start () {

        seenPlayer = false;
        
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        destinationPoint = 0;
    }
	
	// Update is called once per frame
	void Update () {

        distance = Vector3.Distance(player.transform.position, transform.position);

            if (transform.position == points[destinationPoint].position)
            {
                destinationPoint = (destinationPoint + 1);
            }

            if(destinationPoint >= points.Length)
            {
                destinationPoint = 0;
            }

        if (seenPlayer == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[destinationPoint].position, speed * Time.deltaTime);
        }
        if (seenPlayer == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

            if (distance > 7)
            {
                seenPlayer = false;
                transform.position = points[destinationPoint - 1].position;
            }

            
        }

    }
        
    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            seenPlayer = true;
            
            
        }
    }
    

 
}


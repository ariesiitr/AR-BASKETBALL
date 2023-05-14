using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;
using TMPro; 

public class throwball : MonoBehaviour
{
    public float flickForce = 10f;
    public float maxDragDistance = 2f; 
    public Rigidbody rb; 
    public Transform spawnPoint;
    public float respawnDelay = 3f;
    private Vector2 dragStartPosition;
    private Vector2 dragEndPosition;
    private bool isRespawning;
    public float yforce;
    public float forcemultiplier;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void RespawnBall()
    {
        rb.velocity = Vector3.zero; // reset the ball's velocity
        rb.angularVelocity = Vector3.zero; // reset the ball's angular velocity
        transform.position = spawnPoint.position; // move the ball back to the spawn point
        isRespawning = false;

    }
    // Update is called once per frame
    void Update()
    {
        
        if (!isRespawning && Input.touchCount > 0) // check if the player has touched the screen and the ball is not respawning
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) // check if this is the start of a touch
            {
                dragStartPosition = touch.position; // store the starting position of the drag
               
            }
            else if (touch.phase == TouchPhase.Ended) // check if this is the end of a touch
            {
                dragEndPosition = touch.position; // store the ending position of the drag

                Vector2 dragDirection = (dragEndPosition - dragStartPosition)/10; // calculate the direction of the flick

                float dragDistance = Mathf.Min(dragDirection.magnitude, maxDragDistance); // calculate the distance of the drag
                Vector3 force = new Vector3(dragDirection.x, yforce, dragDirection.y) * dragDistance * flickForce * forcemultiplier; // calculate the force with which to flick the ball

                rb.AddForce(force, ForceMode.Impulse); // apply the force to the ball
                isRespawning = true;
                Invoke("RespawnBall", respawnDelay); // start the respawn timer
                
            }
        }    
    }


}
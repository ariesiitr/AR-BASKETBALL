using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballcant : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        public float flickForce = 10f; // the force with which the ball will be flicked
    public float maxDragDistance = 2f; // the maximum distance that the player can drag the ball back before releasing it
    public Rigidbody rb; // the rigidbody of the ball
    public Transform spawnPoint; // the spawn point of the ball
    public float respawnDelay = 3f; // the delay before the ball respawns after being thrown

    private Vector2 dragStartPosition;
    private Vector2 dragEndPosition;
    private bool isRespawning;

    void RespawnBall()
    {
        rb.velocity = Vector3.zero; // reset the ball's velocity
        rb.angularVelocity = Vector3.zero; // reset the ball's angular velocity
        transform.position = spawnPoint.position; // move the ball back to the spawn point
        isRespawning = false;
    }
        
    }

    // Update is called once per frame
    void Update()
    {
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

                Vector2 dragDirection = dragEndPosition - dragStartPosition; // calculate the direction of the flick
                dragDirection.Normalize();

                float dragDistance = Mathf.Min(dragDirection.magnitude, maxDragDistance); // calculate the distance of the drag
                Vector3 force = new Vector3(dragDirection.x, 0f, dragDirection.y) * dragDistance * flickForce; // calculate the force with which to flick the ball

                rb.AddForce(force, ForceMode.Impulse); // apply the force to the ball
                isRespawning = true;
                Invoke("RespawnBall", respawnDelay); // start the respawn timer
            }
        }       
    }
}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMove : MonoBehaviour
{
    // Samson Wu
    // Change the code to make EnemyA move back and forth horizontally on its own on the X axis.

    // Conditions you can modify in editor
    public float distanceToTravel = 5f; // How far (in x-direction) from the starting position you want the object to move
    public float durationToReachEnd = 1f; // How fast (in seconds) you want the object to start going backwards
    public bool canMove = true; // Controls whether the object will move (in case you want to stop)

    private Vector3 startPos; // Where the starting position of the object is
    private Vector3 endPos; // Where the ending position of the object will be
    
    void Start()
    {
        startPos = transform.position; // Assign the current position at Start() as the starting position

        // Calculate the ending position by adding the distance in the x-axis to the starting position
        endPos = new Vector3(transform.position.x + distanceToTravel, transform.position.y, transform.position.z);

        // Start the coroutine that handles the back and forth behaviour in the x-direction
        StartCoroutine(HorizontalBehaviourLoop());
    }

    IEnumerator HorizontalBehaviourLoop()
    {
        while (true) // Loops infinitely until gameObject is destroyed
        {
            if (!canMove) // If the you don't want the object to move
            {
                yield return null; // Wait a frame
                continue; // Return to the top of the loop
            }

            if(durationToReachEnd <= 0) // If the duration is 0 or negative
            {
                yield return null; // Wait a frame
                continue; // Return to the top of the loop
            }

            // The code never gets to the actual movement logic if it can't get past the if-statements above

            // Movement Logic
            for(float timer = 0f; timer < durationToReachEnd; timer += Time.deltaTime) // For the duration
            {
                transform.position = Vector3.Lerp(startPos, endPos, timer / durationToReachEnd); // Smoothly move the position to the end
                yield return null; // Waits a frame which handles this specific for-loop like a traditional Update() method
            }
            transform.position = endPos; // Makes sure the current position is exactly at the end after smoothing

            for (float timer = 0f; timer < durationToReachEnd; timer += Time.deltaTime) // For the duration
            {
                transform.position = Vector3.Lerp(endPos, startPos, timer / durationToReachEnd); // Smoothly move the position back to the start
                yield return null; // Waits a frame which handles this specific for-loop like a traditional Update() method
            }
            transform.position = startPos; // Makes sure the current position is exactly back at the start after smoothing
        }
    }
}
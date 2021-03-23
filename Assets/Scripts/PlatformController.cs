using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    // destination / target
    public Transform[] targets;

    // speed
    public float speed = 1;

    bool isMoving = false;

    // next destination
    int nextIndex;

    // Start is called before the first frame update
    void Start()
    {
      // set the player to the first target
      transform.position = targets[0].position;

      // next destination index is 1
      nextIndex = 1;
    }

    // Update is called once per frame
    void Update()
    {

        HandleInput();

        HandleMovement();
    }

    private void HandleInput() 
    {
        // Check if input axis has been activated
        if (Input.GetButtonDown("Fire1"))
        {
            isMoving = !isMoving;
        }
    }

    private void HandleMovement() 
    {
        // if we are not moving exit
        if (!isMoving)
        {
            return;
        }

                // calculate the distance from out target
        float distance = Vector3.Distance(transform.position, targets[nextIndex].position);

        // have we arrived?
        if (distance > 0) 
        {
            // calculate how much we need to move (step) d = v * t
            float step = speed * Time.deltaTime;

            // move by the step
            transform.position = Vector3.MoveTowards(transform.position, targets[nextIndex].position, step);
        } else {
            // if we have arrived, we should update nextIndex
            nextIndex++;

            if (nextIndex == targets.Length) 
            {
                nextIndex = 0;
            }

            isMoving = false;
        }
    }
}

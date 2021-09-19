using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMove : MonoBehaviour
{
    public float radius = 10.0f;
    public float speed = 0.5f;
    private float x;
    private float y;
    private float z;
    private float distance;
    public Transform otherObject;




    // The point we are going around in circles
    private Vector3 basestartpoint;

    // Destination of our current move
    private Vector3 destination;
    // Start of our current move
    private Vector3 start;
    

    // Current move's progress
    private float progress = 0.0f;

    // Use this for initialization
    void Start()
    {
        
        y = transform.localPosition.y;
       
        start = transform.localPosition;
        basestartpoint = transform.localPosition;
        progress = 0.0f;
        
        PickNewRandomDestination();
        distance = Vector3.Distance(otherObject.position, basestartpoint);

    }

    // Update is called once per frame
    void Update()
    {
        
        bool reached = false;
        
       
        // Update our progress to our destination
        progress += speed * Time.deltaTime ;

        // Check for the case when we overshoot or reach our destination
        if (progress >= 1.0f)
        {
            progress = 1.0f;
            reached = true;
            

        }
        
        
            
        
        // Update out position based on our start postion, destination and progress.
        
        //transform.position = Vector3.Lerp(transform.position, Vector3(next.transform.position.x, next.transform.position.y, z), Time.deltaTime * speed);
        distance = Vector3.Distance(otherObject.position, transform.position);
        if (distance < 10)
        {
            reached = true;
        }

        transform.localPosition = (destination * progress) + start * (1 - progress);


        // If we have reached the destination, set it as the new start and pick a new random point. Reset the progress
        if (reached)
        {
       
            start = transform.position;
            PickNewRandomDestination();
                
            progress = 0.0f;


        }
    }

    void PickNewRandomDestination()
    {
        // We add basestartpoint to the mix so that is doesn't go around a circle in the middle of the scene.
        //destination = Random.insideUnitSphere * radius + basestartpoint ;
       
       
                x = Random.Range(-5f, 6f);
                z = Random.Range(-5f, 6f);
            

            destination = new Vector3(x, y, z) * radius + basestartpoint;



        }
}

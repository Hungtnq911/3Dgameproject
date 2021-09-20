using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Patrol : MonoBehaviour
{

    public Transform[] Points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public Transform mark;
    public float radius_sense = 20f;
    private Animator animator;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {
        agent.speed = 20f;
        animator.SetFloat("botSpeed", 0f);
        // Returns if no points have been set up
        if (Points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = Points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % Points.Length;
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.


        float distance = Vector3.Distance(mark.position, transform.position);

        if (distance <= radius_sense)
        {
            agent.SetDestination(mark.position);
            agent.speed = 46f;
            animator.SetFloat("botSpeed", 1f);
        }
        else
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();

    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movement : MonoBehaviour
{
    
    public float radius_sense = 3f;

    Transform mark;
    NavMeshAgent agent;
    public GameObject ringed = null;
    GameObject destiny = null;
    private void Start()
    {
        
        mark = mark_for_death.instance.target.transform;
        agent = GetComponent<NavMeshAgent>();
        
    }

    private void Update()
    {
        float distance = Vector3.Distance(mark.position, transform.position);

        if (distance <= radius_sense)
        {
            agent.SetDestination(mark.position);
        }
        else
        {
            if (destiny == null)
                roaming();
            else
            {

                agent.SetDestination(destiny.transform.position);
                destiny = null;
            }
        }

    }

    private void roaming()
    {
        trap[] bear;
        int i;
        bear = GameObject.FindObjectsOfType<trap>();
        i = bear.Length;
        Debug.Log(i);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius_sense);

    }
}

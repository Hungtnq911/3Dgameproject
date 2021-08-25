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
    List<bool> trust=new List<bool>();
    private void Start()
    {
        
        mark = mark_for_death.instance.target.transform;
        agent = GetComponent<NavMeshAgent>();
        trust.Add(true);
    }

    private void Update()
    {
        float distance = Vector3.Distance(mark.position, transform.position);
        int k;
        if (distance <= radius_sense)
        {
            agent.isStopped=true;
            agent.isStopped = false;
            agent.SetDestination(mark.position);
        }
        else
        {
            if (ringed != null)
            {
                k = Random.Range(0, trust.Count - 1);
                if (trust[k])
                    destiny = ringed;
                ringed = null;
            }

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
        i = Random.Range(0, bear.Length - 1);
        Debug.Log(i);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius_sense);

    }
}

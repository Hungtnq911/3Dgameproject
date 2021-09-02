using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movement : MonoBehaviour
{
    
    public float radius_sense = 3f;

    Transform mark;
    NavMeshAgent agent;
    public trap ringed = null;
    trap destiny = null;
    List<bool> trust=new List<bool>();
    trap[] bear;
    private void Start()
    {
        
        mark = mark_for_death.instance.target.transform;
        agent = GetComponent<NavMeshAgent>();
        trust.Add(true);
        bear = GameObject.FindObjectsOfType<trap>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(mark.position, transform.position);
        int k;
        float distancetrap = new float();
        if (distance <= radius_sense)
        {
            agent.isStopped=true;
            agent.isStopped = false;
            agent.SetDestination(mark.position);
        }
        else
        {
            agent.isStopped = true;
            agent.isStopped = false;
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
                distancetrap = Vector3.Distance(destiny.transform.position, transform.position);
                agent.SetDestination(destiny.transform.position);
                if (distancetrap <=radius_sense)
                {
                    agent.isStopped = true;
                    checking();
                    agent.SetDestination(transform.position);
                    agent.isStopped = false;
                    destiny = null;
                }

            }
        }

    }

    private void roaming()
    {
        float distance= new float();
        int i;
        if (bear.Length > 0)
        {
            
            i = Random.Range(0, bear.Length - 1);
            distance = Vector3.Distance(bear[i].transform.position, transform.position);
            agent.SetDestination(bear[i].transform.position);
            if (distance <2f)
            {
                agent.isStopped = true;
                agent.SetDestination(transform.position);
                agent.isStopped = false;
            }

        }
        else
            agent.isStopped = true;
    }

    void checking()
    {
       
        float distance = Vector3.Distance(mark.position, transform.position);
        trap smell=destiny.GetComponent<trap>();
        if (trust.Count<15)
        {
            if (smell.clue)
                trust.Add(true);
            else
                trust.Add(false);
            if (distance <= radius_sense)
                trust.Add(true);
            else
                trust.Add(false);
        }
        smell.clue = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius_sense);

    }
}

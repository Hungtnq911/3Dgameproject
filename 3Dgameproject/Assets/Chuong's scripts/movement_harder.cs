using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class movement_harder : MonoBehaviour
{
    public float radius_sense = 3f;

    Transform mark;
    NavMeshAgent agent;
    public trap_harder ringed = null;
    trap_harder destiny = null;
    public int marked;
  
    trap_harder[] bear;
    private void Start()
    {

        mark = mark_for_death.instance.target.transform;
        agent = GetComponent<NavMeshAgent>();
        
        bear = GameObject.FindObjectsOfType<trap_harder>();
        foreach (var tear in bear)
        {
            tear.trust.Add(true);
        }
    }

    private void Update()
    {
        Vector3 bot = transform.position;
        Collider[] nearby_trap_harder = Physics.OverlapSphere(bot, radius_sense);
        List<trap_harder> mear = new List<trap_harder> ();
        foreach (var nearby in nearby_trap_harder)
        {
            if (nearby.CompareTag("player"))
            {
                agent.isStopped = true;
                agent.isStopped = false;
                agent.SetDestination(mark.position);
            }

            if (nearby.CompareTag("trap"))
                mear.Add(nearby.GetComponent<trap_harder>());

        }

        float distance = Vector3.Distance(mark.position, transform.position);
        int k;
        float distancetrap_harder = new float();
        if (distance <= radius_sense)
        {
            agent.isStopped = true;
            agent.isStopped = false;
            agent.SetDestination(mark.position);
        }
        else
        {
            agent.isStopped = true;
            agent.isStopped = false;
            if (ringed != null)
            {
                k = Random.Range(0, ringed.trust.Count - 1);
                if (ringed.trust[k])
                    destiny = ringed;
                ringed = null;
            }

            if (destiny == null)
                roaming(mear);
            else
            {
                distancetrap_harder = Vector3.Distance(destiny.transform.position, transform.position);
                agent.SetDestination(destiny.transform.position);
                if (distancetrap_harder < 1f)
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

    private void roaming(List<trap_harder> mear)
    {
        float distance = new float();
        int i;
        if (mear.Count > 0)
        {

            i = Random.Range(0, mear.Count - 1);
            distance = Vector3.Distance(mear[i].transform.position, transform.position);
            agent.SetDestination(mear[i].transform.position);
            if (distance < 2f)
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
        trap_harder smell = destiny.GetComponent<trap_harder>();
        

        if (destiny.trust.Count < 15)
        {
            if (smell.clue)
                destiny.trust.Add(true);
            else
                destiny.trust.Add(false);
            if (distance <= radius_sense)
                destiny.trust.Add(true);
            else
                destiny.trust.Add(false);
        }
        smell.clue = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius_sense);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap_harder : MonoBehaviour
{
    public bool clue = false;
    public float radius_sense = 3f;
    trigger trigger = null;
    public List<bool> trust = new List<bool>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = new float();
        
        Collider[] trigger = Physics.OverlapSphere(this.transform.position, radius_sense);

        if (trigger != null)
        {
            foreach (var check in trigger)
            {
                if ((check.CompareTag("player")) || (check.CompareTag("trigger")))
                {
                    ringing();
                    trigger = null;
                }
            }
        }


    }

    void ringing()
    {
        movement_harder bot;
        bot = FindObjectOfType<movement_harder>();
        if (bot.ringed == null)
        {
            bot.ringed = this;
            bot.marked = this.GetInstanceID();
            if (trigger.CompareTag("Player"))
                clue = true;
            
            //else
            //remove component();
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius_sense);

    }
}

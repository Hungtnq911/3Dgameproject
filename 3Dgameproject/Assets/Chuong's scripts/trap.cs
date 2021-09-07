using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    public bool clue=false;
    public float radius_sense = 5f;

 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // float distance = new float();
        //trigger[] thing= GameObject.FindObjectsOfType<trigger>();
        Collider[] trigger = Physics.OverlapSphere(this.transform.position, radius_sense);
        movement bot;
        bot = FindObjectOfType<movement>();
        if (trigger != null)
        {
            foreach (var check in trigger)
            {
                if ((check.CompareTag("Player")) || (check.CompareTag("trigger")))
                {
                    if (bot.ringed == null)
                    {
                        bot.ringed = this;

                        if (check.CompareTag("Player"))
                            this.clue = true;
                        //else
                        //remove component();
                        
                    }
                    trigger = null;
                }
            }
        }

    }

    void ringing()
    {
        
       

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius_sense);
        
    }
}

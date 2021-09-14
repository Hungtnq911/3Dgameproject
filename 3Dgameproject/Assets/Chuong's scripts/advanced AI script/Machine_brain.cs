using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class Machine_brain : Agent
{
    public float movespedw =1f;
    public float movespedr= 2f;

    public SensorComponent eye;
    public SensorComponent heart;

    public override void CollectObservations(VectorSensor sensor)
    {
       
        
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float movex = actions.ContinuousActions[0];
        float movez = actions.ContinuousActions[1];
      

        transform.position += new Vector3(movex, 0, movez) * Time.deltaTime * movespedw;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, movespedw);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, movespedr);

    }
}

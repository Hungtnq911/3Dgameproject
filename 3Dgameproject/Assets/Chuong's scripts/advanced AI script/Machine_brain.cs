using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class Machine_brain : Agent
{
    
    public SensorComponent eye;
    
    public override void CollectObservations(VectorSensor sensor)
    {
       
        
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float movex = actions.ContinuousActions[0];
        float movey = actions.ContinuousActions[1];
    }
    
}

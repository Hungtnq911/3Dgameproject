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
    public GameObject mark;
    //public SensorComponent eye;
    //public SensorComponent heart;
    float y = new float();
    private void FixedUpdate()
    {
        SetReward(-1f);
    }
    Vector3 kay = new Vector3();
    private void Start()
    {
        kay = this.transform.position;
    }

    private void Update()
    {
   
    }

    public override void OnEpisodeBegin()
    {
        this.transform.position = Vector3.zero;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(this.transform.position);
        sensor.AddObservation(mark.transform.position);
        
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float movex = actions.ContinuousActions[0];
        float movez = actions.ContinuousActions[1];


        this.transform.position += new Vector3(movex, 0, movez) * Time.deltaTime * movespedw;
        
    }
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> ContinuousActions = actionsOut.ContinuousActions;
        ContinuousActions[0] = Input.GetAxisRaw("Horizontal");
        ContinuousActions[1] = Input.GetAxisRaw("Vertical");
        y = ContinuousActions[0];
  
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject==mark)
        {
            
            SetReward(+100f);
            EndEpisode();
        }

        if (collision.gameObject.TryGetComponent<wall>(out wall yes))
        {
            EndEpisode();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, movespedw);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, movespedr);

    }
}

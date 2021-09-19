using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class Machine_brain : Agent
{
    [SerializeField] private MeshRenderer floor;
    [SerializeField] private Material win;
    [SerializeField] private Material lose;

    public float movespedw =1f;
    public float movespedr= 2f;
    public GameObject mark;
    private wall[] Wall ;
    //public SensorComponent eye;
    //public SensorComponent heart;
    float y = new float();
    private void FixedUpdate()
    {
        
    }
    Vector3 kay = new Vector3();
    private void Start()
    {
        kay = transform.localPosition;
    }

    private void Update()
    {
   
    }

    public override void OnEpisodeBegin()
    {
       transform.localPosition = kay;
      //
       mark.transform.localPosition = new Vector3(Random.Range(-48f, +28f), 13.79f, Random.Range(-53.9f, +12.3f));
        //if (mark.GetComponent<random_movement>().isActiveAndEnabled)
        //{
        //    mark.GetComponent<random_movement>().enabled = false;
        //}
        //else mark.GetComponent<random_movement>().enabled = true;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition);
        sensor.AddObservation(mark.transform.localPosition);
       
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        float movex = actions.ContinuousActions[0];
        float movez = actions.ContinuousActions[1];
        float rotate = actions.ContinuousActions[2];

        transform.position += new Vector3(movex, 0, movez) * Time.deltaTime * movespedw;
        Quaternion target = Quaternion.Euler(0, rotate, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime* 0.5f);
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
            
            SetReward(+10f);
            floor.material = win;
            EndEpisode();
        }

        if (collision.gameObject.TryGetComponent<wall>(out wall yes))
        {
            SetReward(-20f);
            floor.material = lose;
            EndEpisode();
        }

        if (collision.gameObject.TryGetComponent<net>(out net yamete))
        {
            SetReward(-50f);
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

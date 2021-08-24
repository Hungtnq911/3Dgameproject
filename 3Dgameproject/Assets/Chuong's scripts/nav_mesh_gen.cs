using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 
public class nav_mesh_gen : MonoBehaviour
{
    public GameObject platform;

    private void Awake()
    {
        platform = GameObject.Find("platform");



    }
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    
}

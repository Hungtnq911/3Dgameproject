using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random_movement : MonoBehaviour
{
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int k=Random.Range(1, 8);
        float i = new float();//Random.Range()
        Vector3 ll = transform.position;
        if (k %2!=0)//x
        {
            i = Random.Range(-48f, 28f);

            if ((transform.position.x + i < 28f) && (transform.position.x + i > -48f))
            {
                ll.x += i;
                transform.position =ll ;
            }
        }
        else //z
        {
            i = Random.Range(-53.9f, 12.3f);
            if ((transform.position.z + i < 12.3f) && (transform.position.z + i > -53.9f))
            {
                ll.z += i ;
                transform.position = ll;
            }

        }
    }
}

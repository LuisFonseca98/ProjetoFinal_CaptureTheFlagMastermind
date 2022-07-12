using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour,UtilsInterface
{

    public GameObject Player;

    public void OnCollisionEnter(Collision collision)
    {
       
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("tp"))
        {
            Player.transform.position = new Vector3(482, 51, 436);
        }
    }


    // Update is called once per frame
    public void Update()
    {
        
    }


}

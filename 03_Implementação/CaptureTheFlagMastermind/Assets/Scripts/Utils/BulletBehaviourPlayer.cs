using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviourPlayer : MonoBehaviour, UtilsInterface
{

    public void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy") || collision.gameObject.CompareTag("enemy"))
        {
            Debug.Log("Balla Aliada Destruída!");
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        throw new System.NotImplementedException();
    }

}

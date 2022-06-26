using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviourEnemy : MonoBehaviour, UtilsInterface
{

    public void Update()
    {
       
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Clickable") || collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Balla Inimiga Destruída!");
            Destroy(gameObject);
        }
    }
}

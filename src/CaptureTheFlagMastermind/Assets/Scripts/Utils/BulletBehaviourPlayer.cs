using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviourPlayer : MonoBehaviour, UtilsInterface
{

    /*private GameObject soldierShip;
    private GameObject hunterShip;
    private GameObject motherShip;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            AudioManager.instance.DamageSound();
        }

        else if(collision.gameObject.CompareTag("enemy") && soldierShip.name == "Soldado")
        {
            Destroy(gameObject);
            //add hp soldier here
            AudioManager.instance.DamageSound();
        }

        else if (collision.gameObject.CompareTag("enemy") && soldierShip.name == "Caça")
        {
            Destroy(gameObject);
            //add hp hunter here
            AudioManager.instance.DamageSound();
        }

        else if (collision.gameObject.CompareTag("enemy") && soldierShip.name == "Mothership")
        {
            Destroy(gameObject);
            //add hp hunter here
            AudioManager.instance.DamageSound();
        }

        else
        {
            StartCoroutine(DestroyProjectile());
        }

    }
    */


    public void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Clickable") || collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Balla Inimiga Destruída!");
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        throw new System.NotImplementedException();
    }

}

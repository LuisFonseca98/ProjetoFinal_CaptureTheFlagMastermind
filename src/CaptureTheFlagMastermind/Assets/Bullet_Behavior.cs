using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Behavior : MonoBehaviour
{
   private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //shipHp = 0;
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}

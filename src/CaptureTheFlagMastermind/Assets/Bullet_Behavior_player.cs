using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Behavior_player : MonoBehaviour
{
   private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            //shipHp = 0;
            Destroy(gameObject);
            Destroy(collision.gameObject);
            AudioManager.instance.DamageSound();
        }
    }
}

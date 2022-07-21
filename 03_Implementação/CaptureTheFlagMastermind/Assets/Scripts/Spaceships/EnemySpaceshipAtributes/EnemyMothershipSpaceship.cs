using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMothershipSpaceship : MonoBehaviour,Spaceship
{
    public float enemyMothershipHP = 1;


    public void TakeDamage(float damage)
    {
        enemyMothershipHP -= damage;
        if (enemyMothershipHP <= 0) Die();

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BulletAlly"))
        {
            TakeDamage(10);
        }
    }

    public void Die()
    {
        GetComponent<VictoryMenu>().enabled = true;
        AudioManager.instance.ExplosionSound();
    }
}

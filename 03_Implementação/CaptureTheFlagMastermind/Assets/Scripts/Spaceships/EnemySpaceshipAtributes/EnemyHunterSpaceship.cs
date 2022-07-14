using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHunterSpaceship : MonoBehaviour, Spaceship
{

    public float enemyHunterHP = 10;

    public void Update()
    {
        if (enemyHunterHP <= 0) Die();
    }

    public void TakeDamage(float damage)
    {
        enemyHunterHP -= damage;
       
    }

    public void Die()
    {
        Destroy(gameObject);
        AudioManager.instance.ExplosionSound();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BulletAlly"))
        {
            TakeDamage(10);
        }
    }


}

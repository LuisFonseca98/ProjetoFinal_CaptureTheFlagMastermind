using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoldierSpaceship : MonoBehaviour, Spaceship
{
    public float enemySoldierHP = 10;
    //public float enemySoldierHP = 125;
    //valor de destruicao para a reputacao: 20 pontos

    public void Update()
    {
        if (enemySoldierHP <= 0) Die();
    }

    public void Die()
    {
        Destroy(gameObject);
        AudioManager.instance.ExplosionSound();
    }

    public void TakeDamage(float damage)
    {
        enemySoldierHP -= damage;
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BulletAlly"))
        {
            TakeDamage(10);
        }
    }


}

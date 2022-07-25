using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoldierSpaceship : MonoBehaviour, Spaceship
{
    //public float enemySoldierHP = 10;
    public float enemySoldierHP = 125;
    //valor de destruicao para a reputacao: 20 pontos

    public void Die()
    {
        AudioManager.instance.ExplosionSound();
        UIController.reputationValue += 20;
        Destroy(gameObject);

    }

    public void TakeDamage(float damage)
    {
        enemySoldierHP -= damage;
        if (enemySoldierHP <= 0) Die();

    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MissileHunter"))
        {
            TakeDamage(10);
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.CompareTag("MissileSoldier"))
        {
            TakeDamage(25);
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.CompareTag("MissileMothership"))
        {
            TakeDamage(75);
            Destroy(collision.gameObject);

        }
    }


}

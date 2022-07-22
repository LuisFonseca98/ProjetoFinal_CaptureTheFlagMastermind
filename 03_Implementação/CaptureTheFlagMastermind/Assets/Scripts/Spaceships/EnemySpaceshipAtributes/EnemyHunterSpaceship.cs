using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHunterSpaceship : MonoBehaviour, Spaceship
{

    public float enemyHunterHP = 10;
    //public float enemyHunterHP = 75;
    //valor de destruicao para a reputacao: 10 pontos

    public void TakeDamage(float damage)
    {
        enemyHunterHP -= damage;
        if (enemyHunterHP <= 0) Die();

    }

    public void Die()
    {

        AudioManager.instance.ExplosionSound();
        UIController.reputationValue += 10;
        Destroy(gameObject);
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MissileHunter"))
        {
            TakeDamage(10);
        }

        if (collision.gameObject.CompareTag("MissileSoldier"))
        {
            TakeDamage(25);
        }

        if (collision.gameObject.CompareTag("MissileMothership"))
        {
            TakeDamage(75);
        }
    }


}

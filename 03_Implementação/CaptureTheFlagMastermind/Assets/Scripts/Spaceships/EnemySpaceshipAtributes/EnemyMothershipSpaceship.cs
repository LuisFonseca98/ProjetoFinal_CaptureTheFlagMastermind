using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMothershipSpaceship : MonoBehaviour,Spaceship
{
    //public float enemyMothershipHP = 10;
    public float enemyMothershipHP = 200;

    public void TakeDamage(float damage)
    {
        enemyMothershipHP -= damage;
        if (enemyMothershipHP <= 0) Die();

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

    public void Die()
    {
        GetComponent<VictoryMenu>().enabled = true;
    }
}

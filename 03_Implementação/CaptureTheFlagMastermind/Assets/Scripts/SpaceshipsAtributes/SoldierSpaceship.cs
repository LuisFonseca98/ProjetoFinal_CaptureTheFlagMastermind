using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldierSpaceship : MonoBehaviour, Spaceship
{
    public Image healthBar;
    public float soldierHP = 125;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BulletEnemy"))
        {
            TakeDamageFromEnemyBullet(10);

        }
    }

    public void Update()
    {

        if (soldierHP <= 0) Die();


    }


    public void TakeDamageFromEnemyBullet(float damage)
    {

        soldierHP -= damage;
        healthBar.fillAmount = soldierHP / 100;
        AudioManager.instance.DamageSound();

    }

    public void Die()
    {
        Destroy(gameObject);
        AudioManager.instance.ExplosionSound();
    }
}

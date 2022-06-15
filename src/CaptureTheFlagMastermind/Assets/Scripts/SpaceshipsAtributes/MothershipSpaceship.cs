using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MothershipSpaceship : MonoBehaviour, Spaceship
{
    public Image healthBar;
    public static float mothershipHP = 200;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BulletEnemy"))
        {
            TakeDamageFromEnemyBullet(200);

        }
    }

    public void Update()
    {

        if (mothershipHP <= 0)
        {
            Die();
        }


    }


    public void TakeDamageFromEnemyBullet(float damage)
    {

        mothershipHP -= damage;
        healthBar.fillAmount = mothershipHP / 100;
        AudioManager.instance.DamageSound();

    }

    public void Die()
    {
        Destroy(gameObject);
        AudioManager.instance.ExplosionSound();
    }


}

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
            TakeDamage(200);

        }
    }


    public void TakeDamage(float damage)
    {

        mothershipHP -= damage;
        healthBar.fillAmount = mothershipHP / 100;
        AudioManager.instance.DamageSound();

        if (mothershipHP <= 0) Die();
        

    }

    public void Die()
    {
        AudioManager.instance.ExplosionSound();
        GetComponent<GameOverMenu>().enabled = true;
    }


}

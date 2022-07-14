using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HunterSpaceship : MonoBehaviour, Spaceship
{

    public Image healthBar;
    public float hunterHP = 75;

    public  void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BulletEnemy"))
        {
            TakeDamage(10);
        }
    }

    public void Update()
    {

        if (hunterHP <= 0) Die();

        
    }


    public void TakeDamage(float damage)
    {

        hunterHP -= damage;
        healthBar.fillAmount = hunterHP/100;
        AudioManager.instance.DamageSound();

    }

    public void Die()
    {
        Destroy(gameObject);
        AudioManager.instance.ExplosionSound();
    }

}
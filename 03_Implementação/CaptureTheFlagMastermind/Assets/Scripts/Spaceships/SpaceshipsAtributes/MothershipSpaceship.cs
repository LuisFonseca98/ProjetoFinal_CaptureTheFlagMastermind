using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MothershipSpaceship : MonoBehaviour, Spaceship
{
    public Image healthBar;
    public static float mothershipHP = 200;
    //public static float mothershipHP = 10;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MissileEnemyHunter"))
        {
            TakeDamage(10);
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.CompareTag("MissileEnemySoldier"))
        {
            TakeDamage(25);
            Destroy(collision.gameObject);

        }

        if (collision.gameObject.CompareTag("MissileEnemyMothership"))
        {
            TakeDamage(75);
            Destroy(collision.gameObject);

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
        GetComponent<GameOverMenu>().enabled = true;
    }


}

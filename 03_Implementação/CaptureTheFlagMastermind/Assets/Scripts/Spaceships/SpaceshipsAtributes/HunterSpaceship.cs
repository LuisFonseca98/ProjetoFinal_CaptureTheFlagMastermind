using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HunterSpaceship : MonoBehaviour, Spaceship
{

    public Image healthBar;
    public float hunterHP = 75;
    //public float hunterHP = 10;

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

        hunterHP -= damage;
        healthBar.fillAmount = hunterHP/100;
        AudioManager.instance.DamageSound();
        if (hunterHP <= 0) Die();


    }

    public void Die()
    {
        AudioManager.instance.ExplosionSound();
        UnitSelections.Instance.RemoveUnitFromList(gameObject);
        UnitSelections.Instance.Deselect(gameObject);
        Destroy(gameObject);
    }

}
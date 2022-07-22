using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoldierSpaceship : MonoBehaviour, Spaceship
{
    public Image healthBar;
    //public float soldierHP = 125;
    public float soldierHP = 10;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("MissileEnemyHunter"))
        {
            TakeDamage(10);
        }

        if (collision.gameObject.CompareTag("MissileEnemySoldier"))
        {
            TakeDamage(25);
        }

        if (collision.gameObject.CompareTag("MissileEnemyMothership"))
        {
            TakeDamage(75);
        }
    }


    public void TakeDamage(float damage)
    {


        soldierHP -= damage;
        healthBar.fillAmount = soldierHP / 100;
        AudioManager.instance.DamageSound();

        if (soldierHP <= 0) Die();

    }

    public void Die()
    {
        AudioManager.instance.ExplosionSound();
        UnitSelections.Instance.RemoveUnitFromList(gameObject);
        UnitSelections.Instance.Deselect(gameObject);
        Destroy(gameObject);
    }
}

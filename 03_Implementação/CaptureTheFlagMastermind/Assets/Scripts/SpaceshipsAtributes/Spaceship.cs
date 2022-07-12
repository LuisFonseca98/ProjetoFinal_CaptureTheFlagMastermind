using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Spaceship
{


    void Update();

    void TakeDamageFromEnemyBullet(float damageAlly);

    void Die();

    void OnCollisionEnter(Collision collision);


}

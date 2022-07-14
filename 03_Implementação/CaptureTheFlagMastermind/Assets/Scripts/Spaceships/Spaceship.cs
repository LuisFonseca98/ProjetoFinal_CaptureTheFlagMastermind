using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Spaceship
{


    void Update();

    void TakeDamage(float damage);

    void Die();

    void OnCollisionEnter(Collision collision);


}

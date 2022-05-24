using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Spaceship
{


    void Awake();

    void Update();

    void Movement();

    void OnCollisionEnter(Collision collision);

}

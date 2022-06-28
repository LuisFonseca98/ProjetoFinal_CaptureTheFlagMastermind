using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface UtilsInterface
{
    public void Update();

    public void OnCollisionEnter(Collision collision);

    public void OnTriggerEnter(Collider other);

}

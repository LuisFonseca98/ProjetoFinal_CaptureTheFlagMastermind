using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviourEnemy : MonoBehaviour, UtilsInterface
{
    public IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(6);
        Destroy(gameObject);
    }

    public void Update()
    {
        StartCoroutine(DestroyProjectile());
    }
}

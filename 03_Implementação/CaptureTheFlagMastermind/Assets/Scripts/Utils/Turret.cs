using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public GameObject projectile;
    public GameObject hipFireprojectile;
    public float timeBetweenAttacks;
    public bool alreadyShoot;



    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
        if (!alreadyShoot)
        {
            GameObject go= Instantiate(projectile, hipFireprojectile.transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody>().AddForce(hipFireprojectile.transform.forward * 3200f, ForceMode.Force);

            Destroy(go,3f);

            alreadyShoot = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
        

    }


    private void ResetAttack()
    {
        alreadyShoot = false;
    }

}

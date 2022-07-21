using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : MonoBehaviour
{

    public float timeBetweenAttacks;
    public bool alreadyAttacked;
    public GameObject projectile;
    public NavMeshAgent agent;
    public GameObject hipfire;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    public void AttackPlayer(Collider collider)
    {

        agent.SetDestination(transform.position);
        transform.LookAt(collider.transform.position);

        /*if (fleet.transform.Find("Soldier") || fleet.transform.Find("Hunter") || fleet.transform.Find("Mothership"))
        {
            agent.SetDestination(transform.position);
            transform.LookAt(fleet.transform.GetChild(0).position);
        }
        */


        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, hipfire.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            alreadyAttacked = true;
            //Invoke(nameof(ResetAttack), timeBetweenAttacks);
            StartCoroutine(nameof(ResetAttack));
        }


    }



    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);
        alreadyAttacked = false;

    }
}

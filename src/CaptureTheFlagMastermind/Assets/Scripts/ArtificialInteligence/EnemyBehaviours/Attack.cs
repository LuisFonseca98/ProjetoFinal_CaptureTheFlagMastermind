using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attack : MonoBehaviour
{

    public float timeBetweenAttacks;
    public bool alreadyAttacked;
    public GameObject projectile;
    public Transform fleet;
    public NavMeshAgent agent;

    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        fleet = GameObject.Find("Fleet").transform;

    }

    public void AttackPlayer()
    {

        if (fleet.transform.Find("Soldier") || fleet.transform.Find("Hunter") || fleet.transform.Find("Mothership"))
        {
            agent.SetDestination(transform.position);
            transform.LookAt(fleet.transform.GetChild(0).position);
        }


        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }


    }



    public void ResetAttack(bool alreadyAttacked)
    {
        alreadyAttacked = false;
    }
}

using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class EnemyBehaviours : MonoBehaviour
{

    private Patrolling patrol;
    private Chase chase;
    private Attack attack;
    public LayerMask whatIsPlayer;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    void Start()
    {
        patrol = GetComponent<Patrolling>();
        chase = GetComponent<Chase>();
        attack = GetComponent<Attack>();
    }

    void FixedUpdate()
    {

        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) patrol.Patroling();
        if (playerInSightRange && !playerInAttackRange) chase.ChasePlayer();
        if (playerInAttackRange && playerInSightRange) attack.AttackPlayer();
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

}
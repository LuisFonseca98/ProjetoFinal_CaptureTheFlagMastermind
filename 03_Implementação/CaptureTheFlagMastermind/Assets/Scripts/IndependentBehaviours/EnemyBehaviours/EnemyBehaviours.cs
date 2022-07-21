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
        Collider[] collidersSightRange = Physics.OverlapSphere(transform.position, sightRange, whatIsPlayer);
        Collider[] collidersAttackRange = Physics.OverlapSphere(transform.position, attackRange, whatIsPlayer);

        //Check for sight and attack range
        playerInSightRange = collidersSightRange.Length > 0;
        playerInAttackRange = collidersAttackRange.Length > 0;

        if (!playerInSightRange && !playerInAttackRange) patrol.Patroling();
        if (playerInSightRange && !playerInAttackRange) chase.ChasePlayer(collidersSightRange[0]);
        if (playerInAttackRange && playerInSightRange) attack.AttackPlayer(collidersAttackRange[0]);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);

    }

}
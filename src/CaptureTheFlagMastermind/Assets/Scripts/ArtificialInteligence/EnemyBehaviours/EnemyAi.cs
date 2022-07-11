using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class EnemyAi : MonoBehaviour
{

    private Patrolling patrol;
    private Chase chase;
    private Attack attack;
    public LayerMask whatIsPlayer;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Start()
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

    /*private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }


    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    


    private void ChasePlayer()
    {

        if (fleet.transform.Find("Soldier") || fleet.transform.Find("Hunter") || fleet.transform.Find("Mothership"))
        {
            agent.SetDestination(fleet.transform.GetChild(0).position);
        }

        

    }

    private void AttackPlayer()
    {

        if (fleet.transform.Find("Soldier") || fleet.transform.Find("Hunter") || fleet.transform.Find("Mothership"))
        {
            agent.SetDestination(transform.position);
            transform.LookAt(fleet.transform.GetChild(0).position);
        }
        ShootProjectile();


    }



    private void ShootProjectile()
    {
        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    */

    

}

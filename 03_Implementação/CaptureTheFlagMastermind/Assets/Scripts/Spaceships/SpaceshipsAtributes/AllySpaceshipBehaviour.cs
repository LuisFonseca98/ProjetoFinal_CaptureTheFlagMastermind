using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AllySpaceshipBehaviour : MonoBehaviour
{

    //Variables for the attack state
    public NavMeshAgent agent;
    public LayerMask whatIsGround, whatIsEnemy;

    //Attacking
    public float timeBetweenAttacks;
    public GameObject projectile;
    public bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool enemyInSightRange, enemyInAttackRange;

    public GameObject hipFireprojectile;


    public void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    void FixedUpdate()
    {

        Collider[] collidersSightRange = Physics.OverlapSphere(transform.position, sightRange, whatIsEnemy);
        Collider[] collidersAttackRange = Physics.OverlapSphere(transform.position, attackRange, whatIsEnemy);

        //Check for sight and attack range
        enemyInSightRange = collidersSightRange.Length > 0;
        enemyInAttackRange = collidersAttackRange.Length > 0;

        
        if (enemyInSightRange && !enemyInAttackRange) ChaseEnemySpaceship(collidersSightRange[0]);
        if (enemyInAttackRange && enemyInSightRange) AttackEnemySpaceship(collidersAttackRange[0]);


    }


    private void ChaseEnemySpaceship(Collider collider)
    {
        agent.SetDestination(collider.transform.position);
    }

    private void AttackEnemySpaceship(Collider collider)
    {
        agent.SetDestination(transform.position);
        transform.LookAt(collider.transform.position);


        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(projectile, hipFireprojectile.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
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

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Spaceship : MonoBehaviour
{
 
     //Variables for the attack state
    public NavMeshAgent agent;
    private Transform enemyFleet;
    public LayerMask whatIsGround, whatIsEnemy;

    //Attacking
    public float timeBetweenAttacks;
    public GameObject projectile;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool enemyInSightRange, enemyInAttackRange;


    public void Awake()
    {
        enemyFleet = GameObject.Find("EnemyFleet").transform;
        agent = GetComponent<NavMeshAgent>();
               
    }

    void FixedUpdate()
    {

        enemyInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsEnemy);
        enemyInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsEnemy);
        if (enemyInSightRange && !enemyInAttackRange) ChaseEnemySpaceship();
        if (enemyInAttackRange && enemyInSightRange) AttackEnemySpaceship();
        

    }


    private void ChaseEnemySpaceship()
    {
        Debug.Log("Entrei1");
        if (enemyFleet.transform.Find("EnemySoldier") || enemyFleet.transform.Find("EnemyHunter") || enemyFleet.transform.Find("EnemyMothership"))
        {
            agent.SetDestination(enemyFleet.transform.GetChild(0).position);
        }

    }

    private void AttackEnemySpaceship()
    {
        Debug.Log("Entrei2");
        if (enemyFleet.transform.Find("EnemySoldier") || enemyFleet.transform.Find("EnemyHunter") || enemyFleet.transform.Find("EnemyMothership"))
        {
            agent.SetDestination(transform.position);
            transform.LookAt(enemyFleet.transform.GetChild(0).position);
        }

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

}
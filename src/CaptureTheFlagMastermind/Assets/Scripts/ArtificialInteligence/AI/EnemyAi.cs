using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform fleet;
    public LayerMask whatIsGround, whatIsPlayer;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    //public Dictionary<string, GameObject> spaceships = new Dictionary<string, GameObject>();

    void Awake()
    {
        //addElements();
        fleet = GameObject.Find("Fleet").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void FixedUpdate()
    {
        
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
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
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    /*private void addElements()
    {
        Unit[] unitsGO = fleet.GetComponentsInChildren<Unit>();
        foreach (Unit unit in unitsGO)
        {
            spaceships.Add(unit.name, unit.gameObject);
        }
    }
    */

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

        

        if (!alreadyAttacked)
        {
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            ///End of attack code

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

    private IEnumerator BackToPatrol()
    {
        yield return new WaitForSeconds(3);
        Patroling();
    }

}

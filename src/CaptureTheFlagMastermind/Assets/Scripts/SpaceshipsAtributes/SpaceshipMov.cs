using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpaceshipMov : MonoBehaviour
{
    Camera cam;
    NavMeshAgent myAgent;
    public LayerMask ground;
    //public static List<NavMeshAgent> meshAgents = new List<NavMeshAgent>();

    //ataque
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public float health;
    //Patroling
    //public Vector3 walkPoint;
    //bool walkPointSet;
    //public float walkPointRange;
    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;


    private void Awake()
    {
        player = GameObject.FindWithTag("enemy").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        cam = Camera.main;
        myAgent = GetComponent<NavMeshAgent>();
        //meshAgents.Add(myAgent);
    }

    void Update()
    {
     //ataque
     //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        //if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();

    









        /*if (meshAgents.Contains(myAgent))
        {
            return;
        }
        else
        {
            meshAgents.Add(myAgent);
        }
        */

        if (Input.GetMouseButtonDown(1)) // && meshAgents.Contains(myAgent))
        {
            //if (meshAgents.IndexOf(myAgent) == 0)
            //{
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                myAgent.SetDestination(hit.point);
            }

            /*
            float angle = 60; // angular step
            int countOnCircle = (int)(360 / angle); // max number in one round
            int count = meshAgents.Count; // number of agents
            float step = 1; // circle number
            int i = 1; // agent serial number
            float randomizeAngle = Random.Range(0, angle);
            while (count > 1)
            {
                var vec = Vector3.forward;
                vec = Quaternion.Euler(0, angle * (countOnCircle - 1) + randomizeAngle, 0) * vec;
                meshAgents[i].SetDestination(myAgent.destination + vec * (myAgent.radius + meshAgents[i].radius + 0.5f) * step);
                countOnCircle--;
                count--;
                i++;
                if (countOnCircle == 0)
                {
                    if (step != 3 && step != 4 && step < 6 || step == 10) { angle /= 2f; }

                    countOnCircle = (int)(360 / angle);
                    step++;
                    randomizeAngle = Random.Range(0, angle);
                }
            }

            */
            //}
        }
    }

    /*void OnDisable()
    {
        meshAgents.Clear();
    }
    */


    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            //rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

  //  public void TakeDamage(int damage)
   // {
   //     health -= damage;

   //     if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
   // }

   // private void DestroyEnemy()
   // {
    //    Destroy(gameObject);
    //}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpaceshipStateMachine : MonoBehaviour
{

    Camera cam;
    NavMeshAgent myAgent;

    public NavMeshAgent agent;
    public LayerMask ground;
    public Transform player;
    public States state;

    // Start is called before the first frame update
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        myAgent = GetComponent<NavMeshAgent>();
        state = States.IDLE;
        cam = Camera.main;
        player = GameObject.FindWithTag("enemy").transform;

    }

    // Update is called once per frame
    void Update()
    {
        StateMachine();
    }


    public void StateMachine()
    {

    }


    public void ActivatedProps()
    {

    }


    public void SetDestination()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                myAgent.SetDestination(hit.point);
            }
        }
    }

    public void ChaseEnemySpaceship()
    {
        agent.SetDestination(player.position);
    }

    /**
     * Debugger to see the distance of the sight and attack range
     */
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        //Gizmos.DrawWireSphere(transform.position, sightRange);
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    public NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    public void ChasePlayer(Collider collider)
    {

        agent.SetDestination(collider.transform.position);

        /*if (fleet.transform.Find("Soldier") || fleet.transform.Find("Hunter") || fleet.transform.Find("Mothership"))
        {


            agent.SetDestination(fleet.transform.GetChild(0).position);
        }

        */


    }
}

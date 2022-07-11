using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour
{
    public Transform fleet;
    public NavMeshAgent agent;

    private void Start()
    {
        fleet = GameObject.Find("Fleet").transform;
        agent = GetComponent<NavMeshAgent>();
    }


    public void ChasePlayer()
    {

        if (fleet.transform.Find("Soldier") || fleet.transform.Find("Hunter") || fleet.transform.Find("Mothership"))
        {
            agent.SetDestination(fleet.transform.GetChild(0).position);
        }


    }
}

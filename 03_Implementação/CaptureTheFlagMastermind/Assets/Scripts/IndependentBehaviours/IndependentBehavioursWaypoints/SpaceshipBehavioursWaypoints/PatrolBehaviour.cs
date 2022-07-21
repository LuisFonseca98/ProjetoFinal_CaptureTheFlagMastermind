using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehaviour : AIBehaviour
{
	//private Animator animator;
	private NavMeshAgent navMeshAgent;
	
	private GameObject[] waypoints;
	private int currentWaypoint = -1;
	
	private Transform player;
	
	
	
	public  PatrolBehaviour(AIAgent agent, GameObject[] waypoints) : base(agent)
	{
		//animator = agent.GetComponent<Animator>();
		navMeshAgent = agent.GetComponent<NavMeshAgent>();
		this.waypoints = waypoints;
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	public override void Begin()
	{
		//animator.SetBool("patrol", true);
		SetNextWaypoint();
	}
	
	public override void End()
	{
		//animator.SetBool("patrol", false);
	}
	
	
	public override void Update()
	{
		 if(navMeshAgent.remainingDistance < 0.25f)
		{
		 agent.HandleEvent(AIEvent.ReachedDestination);
		}
		if(AIUtils.HasVision(agent.transform, player.position))
		{
			agent.HandleEvent(AIEvent.SpottedPlayer);
		}
	}
	
	private void SetNextWaypoint()
	{
		currentWaypoint++;
		currentWaypoint = currentWaypoint % waypoints.Length;
		navMeshAgent.SetDestination(waypoints[currentWaypoint].transform.position);
	}
    
}
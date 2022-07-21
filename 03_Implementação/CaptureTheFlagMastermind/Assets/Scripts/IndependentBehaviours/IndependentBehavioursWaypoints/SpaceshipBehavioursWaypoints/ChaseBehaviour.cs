using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseBehaviour : AIBehaviour
{
	//private Animator animator;
	private NavMeshAgent navMeshAgent;
	private Transform player;
	
	
	
	
	
	public  ChaseBehaviour(AIAgent agent) : base(agent)
	{
		//animator = agent.GetComponent<Animator>();
		navMeshAgent = agent.GetComponent<NavMeshAgent>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		
	}

	public override void Begin()
	{
		//animator.SetBool("chase", true);

	}

	public override void End()
	{
		//animator.SetBool("chase", false);
	}


	public override void Update()
	{
		 navMeshAgent.SetDestination(player.position);
		 
		if( ! AIUtils.HasVision(agent.transform, player.position))
		{
			agent.HandleEvent(AIEvent.LostTarget);
		}
		
		if(Vector3.Distance(player.position, agent.transform.position) < 1.5)
		{
			agent.HandleEvent(AIEvent.TargetInRange);
		}
	}
	
	
    
}
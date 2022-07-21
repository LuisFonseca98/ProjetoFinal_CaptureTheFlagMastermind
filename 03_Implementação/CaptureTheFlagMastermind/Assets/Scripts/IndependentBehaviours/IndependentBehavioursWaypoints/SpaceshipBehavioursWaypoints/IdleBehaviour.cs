using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleBehaviour : AIBehaviour
{

	//private Animator animator;
	private Transform player;
	
	public  IdleBehaviour(AIAgent agent) : base(agent)
	{
		//animator = agent.GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	public override void Begin()
	{
		//animator.SetBool("idle",true);
		agent.StartCoroutine(RestRoutine());
	}
	
	public override void End()
	{
		//animator.SetBool("idle",false);
	}


	public override void Update()
	{
		if(AIUtils.HasVision(agent.transform, player.position))
		{
			agent.HandleEvent(AIEvent.SpottedPlayer);
		}
	}
	
	public IEnumerator RestRoutine()
	{
		yield return new WaitForSeconds(2);
		
		agent.HandleEvent(AIEvent.Rested);
	}
    
}
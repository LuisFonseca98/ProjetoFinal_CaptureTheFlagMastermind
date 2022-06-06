using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackBehaviour : AIBehaviour
{
	//private Animator animator;
	
	private Transform player;
	
	
	public  AttackBehaviour(AIAgent agent) : base(agent)
	{
		//animator = agent.GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		
	}

	public override void Begin()
	{
		
		agent.StartCoroutine(AttackRoutine());
		

	}
	
	public override void End()
	{
		
		agent.StopAllCoroutines();
	}
	
	
	public override void Update()
	{
		
		if( ! AIUtils.HasVision(agent.transform, player.position))
		{
			agent.HandleEvent(AIEvent.LostTarget);
		}
		
		if(Vector3.Distance(player.position, agent.transform.position) > 1.5)
		{
			agent.HandleEvent(AIEvent.TargetTooFarAway);
		}
		
		agent.transform.LookAt(player.position, Vector3.up);
	}
	
	private IEnumerator AttackRoutine()
	{
		
		while(true)
		{
			//animator.SetTrigger("attack");

			yield return new WaitForSeconds(5);
		}
		
	}
	
	
    
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpaceshipAllyStateMachine : StateMachine
{
	
	public AIState GetNextState(AIState current, AIEvent aIEvent)
	{
		
		if(current == AIState.Idle)
		{
			if(aIEvent == AIEvent.Rested)
			{
				return AIState.Patrol;
			}
			
			if(aIEvent == AIEvent.SpottedPlayer)
			{
				return AIState.Chase;
			}
			
		}
		
		if(current == AIState.Patrol)
		{
			if(aIEvent == AIEvent.ReachedDestination)
			{
				return AIState.Idle;
			}
			
			if(aIEvent == AIEvent.SpottedPlayer)
			{
				return AIState.Chase;
			}
		}
		
		if(current == AIState.Chase)
		{
			if(aIEvent == AIEvent.LostTarget)
			{
				return AIState.Idle;
			}
			
			if(aIEvent == AIEvent.TargetInRange)
			{
				return AIState.Attack;
			}
			
		}
		
		if(current == AIState.Attack)
		{
			if(aIEvent == AIEvent.LostTarget)
			{
				return AIState.Idle;
			}
			
			if(aIEvent == AIEvent.TargetTooFarAway)
			{
				return AIState.Chase;
			}
			
		}
		
		return AIState.Idle;
		
		
		
		

	}
    
}
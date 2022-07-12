using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Demon : AIAgent
{
    
	private NavMeshAgent agent;
	private Animator animator;
	private StateMachine stateMachine;
	
	public GameObject[] waypoints;
	
	private AIState currentState;
	private AIBehaviour currentBehaviour;
	private Dictionary<AIState,AIBehaviour> behaviours;
	
	
   
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
	   animator = GetComponent<Animator>();
	   
	   stateMachine = new SpaceshipAllyStateMachine();
	   
	   behaviours = new Dictionary<AIState,AIBehaviour>();
	   behaviours.Add(AIState.Idle, new IdleBehaviour(this));
	   behaviours.Add(AIState.Patrol, new PatrolBehaviour(this, waypoints));
	   behaviours.Add(AIState.Chase, new ChaseBehaviour(this));
	   behaviours.Add(AIState.Attack, new AttackBehaviour(this));
	   
	   
	   HandleEvent(AIEvent.ReachedDestination);
    }

    void Update()
    {
     
	
	 if(currentBehaviour != null)
	 {
		 currentBehaviour.Update();
	 }
	 
	 
	 
    }
	
	public override void HandleEvent(AIEvent aIEvent)
	{
		if(currentBehaviour != null)
		{
		 currentBehaviour.End();
		}
		
		currentState = stateMachine.GetNextState( currentState,  aIEvent);
		currentBehaviour = behaviours[currentState];
		
		
		if(currentBehaviour != null)
		{
		 currentBehaviour.Begin();
		}
	}
	
	private void OnAnimatorMove()
	{
		agent.speed = (animator.deltaPosition / Time.deltaTime).magnitude;
	}

   


    
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public interface StateMachine 
{
	
	AIState GetNextState(AIState current, AIEvent aIEvent);
    
}
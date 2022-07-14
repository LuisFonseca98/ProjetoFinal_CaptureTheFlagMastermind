using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class AIBehaviour
{
	
	protected AIAgent agent;
	
	public AIBehaviour(AIAgent agent)
	{
		this.agent = agent; 
	}

	public abstract void Begin();
	
	public abstract void End();
	
	public abstract void Update();
	
    
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIUtils 
{
	
	
	public static bool HasVision( Transform enemy, Vector3 target)
	{
		
		Vector3 dir = target - enemy.position;
		
		if(Mathf.Abs( Vector3.Angle(dir, enemy.forward)) < Constants.EnemyConeVision)
		{
			return true;
		}
		return false;
		
	}
	
    
}
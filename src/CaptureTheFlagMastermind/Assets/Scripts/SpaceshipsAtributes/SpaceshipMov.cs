using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpaceshipMov : MonoBehaviour
{
    Camera cam;
    NavMeshAgent myAgent;
    public LayerMask ground;

  
    
    private void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();
        cam = Camera.main;
    }

    void Update()
    {

               SendSpaceshipToLocation();

    }

    public void SendSpaceshipToLocation()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                myAgent.SetDestination(hit.point);
            }
        }

    }


    

}
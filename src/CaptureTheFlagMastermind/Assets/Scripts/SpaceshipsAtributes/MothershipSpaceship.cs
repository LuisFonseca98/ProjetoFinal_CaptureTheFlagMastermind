using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MothershipSpaceship : MonoBehaviour,Spaceship
{
    private Rigidbody rb;

    public float speed = 10f;

    Camera cam;
    NavMeshAgent myAgent;
    public LayerMask ground;


    public void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        myAgent = GetComponent<NavMeshAgent>();
        //meshAgents.Add(myAgent);
    } 


    public void Update()
    {
        Movement();
    }

    public void Movement()
    {
        if (Input.GetMouseButtonDown(1)) // && meshAgents.Contains(myAgent))
        {
            //if (meshAgents.IndexOf(myAgent) == 0)
            //{
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            
            if (Physics.Raycast(ray, out hit, ground))
            {
                float xMov = Input.GetAxisRaw("Horizontal");
                float zMov = Input.GetAxisRaw("Vertical");
                //float velX = rb.velocity.x * transform.position.x + speed;
                //float velZ = rb.velocity.z * transform.position.z + speed;
                Vector3 hitVelocity = new Vector3(xMov, 0, zMov) * Time.deltaTime;
                myAgent.SetDestination(hitVelocity);
            }

        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacule"))
        {
            Debug.Log("Hit by a obstacule!");
        }
    }
}

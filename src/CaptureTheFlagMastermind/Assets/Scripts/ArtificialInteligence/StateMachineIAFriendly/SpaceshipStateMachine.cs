using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpaceshipStateMachine : MonoBehaviour
{

    Camera myCam;
    NavMeshAgent myAgent;

    public NavMeshAgent agent;
    public LayerMask ground;
    public LayerMask clickable;

    public Transform enemy;
    public States state;
    public GameObject groundMarker;

    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> unitsSelected = new List<GameObject>();

    private static SpaceshipStateMachine _instance;
    public static SpaceshipStateMachine Instance { get { return _instance; } }

    // Start is called before the first frame update
    private void Awake()
    {

        agent = GetComponent<NavMeshAgent>();
        myAgent = GetComponent<NavMeshAgent>();
        state = States.IDLE;
        myCam = Camera.main;
        enemy = GameObject.Find("EnemyFleet").transform;
        _instance = this;

    }

    // Update is called once per frame
    void Update()
    {

        StateMachine();

    }


    public void StateMachine()
    {
        RaycastHit hit;
        Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

        switch (state)
        {

            case States.IDLE:
                if (Input.GetMouseButton(0) &&
                    Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
                {
                    state = States.SELECTED;
                    AddSpaceshipToList(hit.collider.gameObject);
                    ActivateProps();

                }
                break;

            case States.SELECTED:

                if (Input.GetMouseButton(0) &&
                    !(Physics.Raycast(ray, out hit, Mathf.Infinity, clickable)))
                {

                    state = States.IDLE;
                    DeactivateProps();

                }

                if (Input.GetMouseButton(1))
                {
                    state = States.MOVE;
                }

                break;

            case States.MOVE:

                StartCoroutine(TimeToChangeToIdle());

                break;

            case States.CHASE:
                ChaseEnemySpaceship();
                break;

            case States.ATTACK:
                break;

        }

    }

    public void ActivateProps()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(3).gameObject.SetActive(true);
        gameObject.transform.GetChild(4).gameObject.SetActive(true);

    }

    public void DeactivateProps()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(3).gameObject.SetActive(false);
        gameObject.transform.GetChild(4).gameObject.SetActive(false);

    }


    public void SetDestination()
    {

        RaycastHit hit;
        Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
        {
            groundMarker.transform.position = hit.point;
            groundMarker.SetActive(false);
            groundMarker.SetActive(true);
            myAgent.SetDestination(hit.point);
            AudioManager.instance.GenerateRandomAudioClip();

        }

    }


    public void AddSpaceshipToList(GameObject unitToAdd)
    {
        DeselectAll();
        unitsSelected.Add(unitToAdd);

    }

    public void DeselectAll()
    {
        foreach (var unit in unitsSelected)
        {
            DeactivateProps();
        }
        unitsSelected.Clear();
    }


    public void ChaseEnemySpaceship()
    {
        agent.SetDestination(enemy.position);
    }



    /**
     * Debugger to see the distance of the sight and attack range
     */
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        //Gizmos.DrawWireSphere(transform.position, sightRange);
    }


    public IEnumerator TimeToChangeToIdle()
    {
        SetDestination();
        yield return new WaitForSeconds(6);
        DeactivateProps();
        state = States.IDLE;

    }

}
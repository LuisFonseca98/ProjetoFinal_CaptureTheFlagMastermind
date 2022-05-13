using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitClick : MonoBehaviour
{

    //variables for the camera and the marker gameobject
    private Camera myCam;
    public GameObject groundMarker;

    //variables for the diferent layers
    public LayerMask clickable;
    public LayerMask ground;


    void Start()
    {
        myCam = Camera.main;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //if we hit a clickable object
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit,Mathf.Infinity, clickable))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    //shift clicked
                    UnitSelections.Instance.ShiftClickSelect(hit.collider.gameObject);
                }
                else
                {
                    //normal clicked
                    UnitSelections.Instance.ClickSelect(hit.collider.gameObject);

                }
            }
            else
            {
                if (!Input.GetKey(KeyCode.RightShift))
                {
                    UnitSelections.Instance.DeselectAll();
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray,out hit, Mathf.Infinity, ground))
            {
                groundMarker.transform.position = hit.point;
                AudioManager.instance.GenerateRandomAudioClip();
                groundMarker.SetActive(false);
                groundMarker.SetActive(true);
            }
        }
    }
    
}

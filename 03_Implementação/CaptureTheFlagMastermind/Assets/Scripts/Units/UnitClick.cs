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
        
        SelectDiferentUnits();
        SendUnitsWithClick();

    }


    public void SelectDiferentUnits()
    {
        if (Input.GetMouseButtonDown(0)) //LMB 
        {
            //if we hit a clickable object
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
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
    }

    public void SendUnitsWithClick()
    {
        if (Input.GetMouseButtonDown(1)) //RMB
        {
            RaycastHit hit;
            Ray ray = myCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                groundMarker.transform.position = hit.point;
                groundMarker.SetActive(false);
                groundMarker.SetActive(true);
                AudioManager.instance.GenerateRandomAudioClip();

            }
        }
    }

    

}

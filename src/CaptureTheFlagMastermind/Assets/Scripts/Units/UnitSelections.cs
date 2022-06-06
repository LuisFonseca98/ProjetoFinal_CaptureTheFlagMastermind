using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelections : MonoBehaviour
{

    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> unitsSelected = new List<GameObject>();


    private static UnitSelections _instance;
    public static UnitSelections Instance { get { return _instance;}}

    //private GameObject particles;


    public void Awake()
    {
        //if an instance of this already exists and it isnt this one
        if(_instance != null && _instance != this)
        {
            //we destroy this instance
            Destroy(this.gameObject);
        }
        else
        {   
            //make this the instance
            _instance = this;
        }
    }

    public void ClickSelect(GameObject unitToAdd)
    {
        DeselectAll(); 
        unitsSelected.Add(unitToAdd);
        unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        unitToAdd.transform.GetChild(3).gameObject.SetActive(true);
        unitToAdd.transform.GetChild(4).gameObject.SetActive(true);
        unitToAdd.GetComponent<SpaceshipMov>().enabled = true;
    }

    public void ShiftClickSelect(GameObject unitToAdd)
    {
        if (!unitsSelected.Contains(unitToAdd))
        {
            unitsSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.transform.GetChild(3).gameObject.SetActive(true);
            unitToAdd.transform.GetChild(4).gameObject.SetActive(true);
            unitToAdd.GetComponent<SpaceshipMov>().enabled = true;
        }
        else
        {
            unitToAdd.GetComponent<SpaceshipMov>().enabled = false;
            unitToAdd.transform.GetChild(0).gameObject.SetActive(false);
            unitToAdd.transform.GetChild(3).gameObject.SetActive(false);
            unitToAdd.transform.GetChild(4).gameObject.SetActive(false);
            unitsSelected.Remove(unitToAdd);
        }
    }

    public void DragSelect(GameObject unitToAdd)
    {
        if (!unitsSelected.Contains(unitToAdd))
        {
            unitsSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.transform.GetChild(3).gameObject.SetActive(true);
            unitToAdd.transform.GetChild(4).gameObject.SetActive(true);
            unitToAdd.GetComponent<SpaceshipMov>().enabled = true;
        }
    }

    public void DeselectAll()
    {
        foreach(var unit in unitsSelected)
        {
            unit.GetComponent<SpaceshipMov>().enabled = false;
            unit.transform.GetChild(0).gameObject.SetActive(false);
            unit.transform.GetChild(3).gameObject.SetActive(false);
            unit.transform.GetChild(4).gameObject.SetActive(false);

        }
        unitsSelected.Clear();
    }

    public void Deselect(GameObject unitToDeselect)
    {

    }



}

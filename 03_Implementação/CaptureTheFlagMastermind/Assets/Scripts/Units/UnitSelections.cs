using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;
public class UnitSelections : MonoBehaviour
{

    public List<GameObject> unitList = new List<GameObject>();
    public List<GameObject> unitsSelected = new List<GameObject>();

    public GameObject displayInfoWindowSpaceship;
    public TMP_Text nameSpaceship;
    public TMP_Text accValue;
    public TMP_Text velValue;

    private static UnitSelections _instance;
    public static UnitSelections Instance { get { return _instance; } }

    public void Awake()
    {
        //if an instance of this already exists and it isnt this one
        if (_instance != null && _instance != this)
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
        RemoveUnitFromList();
        DeselectAll();
        ActiveWindowSpaceshipInfo();
        ObtainSpaceshipInfo();

        unitsSelected.Add(unitToAdd);
        unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
        unitToAdd.transform.GetChild(3).gameObject.SetActive(true);
        unitToAdd.transform.GetChild(4).gameObject.SetActive(true);
        unitToAdd.GetComponent<SpaceshipMov>().enabled = true;

    }

    public void ShiftClickSelect(GameObject unitToAdd)
    {

        RemoveUnitFromList();


        if (!unitsSelected.Contains(unitToAdd))
        {
            unitsSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.transform.GetChild(3).gameObject.SetActive(true);
            unitToAdd.transform.GetChild(4).gameObject.SetActive(true);
            unitToAdd.GetComponent<SpaceshipMov>().enabled = true;
            ActiveWindowSpaceshipInfo();
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
        RemoveUnitFromList();
        if (!unitsSelected.Contains(unitToAdd))
        {
            DeactiveWindowSpaceshipInfo();
            unitsSelected.Add(unitToAdd);
            unitToAdd.transform.GetChild(0).gameObject.SetActive(true);
            unitToAdd.transform.GetChild(3).gameObject.SetActive(true);
            unitToAdd.transform.GetChild(4).gameObject.SetActive(true);
            unitToAdd.GetComponent<SpaceshipMov>().enabled = true;
        }
    }

    public void DeselectAll()
    {
        RemoveUnitFromList();
        foreach (var unit in unitsSelected)
        {
            DeactiveWindowSpaceshipInfo();
            unit.GetComponent<SpaceshipMov>().enabled = false;
            unit.transform.GetChild(0).gameObject.SetActive(false);
            unit.transform.GetChild(3).gameObject.SetActive(false);
            unit.transform.GetChild(4).gameObject.SetActive(false);

        }
        unitsSelected.Clear();
    }

    public void Deselect(GameObject unitToDeselect)
    {
        DeactiveWindowSpaceshipInfo();
        unitToDeselect.GetComponent<SpaceshipMov>().enabled = false;
        unitToDeselect.transform.GetChild(0).gameObject.SetActive(false);
        unitToDeselect.transform.GetChild(3).gameObject.SetActive(false);
        unitToDeselect.transform.GetChild(4).gameObject.SetActive(false);
        unitsSelected.Remove(unitToDeselect);

    }

    public void ObtainSpaceshipInfo()
    {
        if (unitsSelected.Count > 1 || unitsSelected.Count == 0 || unitsSelected == null) return;
        nameSpaceship.text = unitsSelected[0].name;
        accValue.text = unitsSelected[0].GetComponent<NavMeshAgent>().speed.ToString();
        velValue.text = unitsSelected[0].GetComponent<NavMeshAgent>().acceleration.ToString();
    }


    public void ActiveWindowSpaceshipInfo()
    {
       
        displayInfoWindowSpaceship.SetActive(true);

    }

    public void DeactiveWindowSpaceshipInfo()
    {
        
        displayInfoWindowSpaceship.SetActive(false);

    }

    public void RemoveUnitFromList()
    {
        for (int i = unitList.Count - 1; i >= 0; i--)
        {
            if (unitList[i] == null && unitsSelected.Count >= 0)
            {
                unitList.RemoveAt(unitList.Count - 1);
                unitList[i] = unitList[unitList.Count - 1];
            }
        }
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public GameObject tpToTravel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.position += new Vector3(tpToTravel.transform.position.x - transform.position.x, 
               other.transform.position.y,
               tpToTravel.transform.position.z - transform.position.z) * 1.1f;
            UnitSelections.Instance.Deselect(other.gameObject);
            other.GetComponent<SpaceshipMov>().SetLocation(other.transform.position);

        }
    }


}

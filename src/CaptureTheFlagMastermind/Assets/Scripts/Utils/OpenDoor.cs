using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject Door;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().gameObject.layer == LayerMask.NameToLayer("Clickable") || other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Yay2!");
            Door.SetActive(false);
        }
    }


}

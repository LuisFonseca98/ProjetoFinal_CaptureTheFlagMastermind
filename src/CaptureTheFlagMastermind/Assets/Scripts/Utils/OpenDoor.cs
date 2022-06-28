using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour,UtilsInterface
{
    public GameObject Door;

    public void OnCollisionEnter(Collision collision){ throw new System.NotImplementedException(); }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().gameObject.layer == LayerMask.NameToLayer("Clickable") || other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Yay2!");
            Door.SetActive(false);
        }
    }

    public void Update(){  }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour  
{

    private Camera main_camera;


    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("MainCamera");
        main_camera = player.GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(main_camera.transform);
    }
}
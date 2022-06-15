using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour,UIInterface  
{

    private Camera main_camera;

    public void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("MainCamera");
        main_camera = player.GetComponentInChildren<Camera>();
    }

    public void Update()
    {
        transform.LookAt(main_camera.transform);
    }








}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSky : MonoBehaviour,UtilsInterface
{
    public float RotateSpeed = 1.2f;

    public IEnumerator DestroyProjectile()
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * RotateSpeed);
    }
}

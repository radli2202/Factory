using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Muve : MonoBehaviour
{
    Rigidbody rb;
    Transform ThisTr;
    float Angle = 25f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ThisTr = GetComponent<Transform>();
    }

    public void Muvet(Vector3 vec)
    {
        rb.velocity = vec;
       
    }

    public void Rotat(Vector3 vectorroot, Transform CamerTr)
    {
        vectorroot = CamerTr.TransformDirection(vectorroot);
        vectorroot = new Vector3(vectorroot.x, 0, vectorroot.z);

        if (Mathf.Abs(vectorroot.z) > 0 || Mathf.Abs(vectorroot.x) > 0)
        ThisTr.rotation = Quaternion.Lerp(ThisTr.rotation, Quaternion.LookRotation(vectorroot), Angle * Time.deltaTime);
              
    }
}

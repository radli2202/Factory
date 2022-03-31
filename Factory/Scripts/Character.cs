using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] Transform Camer;

    Muve muv;
    [SerializeField] MobileInput Input;


    public int Resurs_1, Resurs_2;

    void Start()
    {
        Camer = Camer.GetComponent<Transform>();
        Input = Input.GetComponent<MobileInput>();
        muv = GetComponent<Muve>();
    }

    void Update()
    {
        Vector3 vec = Vector3.zero;
        vec.x = Input.Horizontal()*speed;
        vec.z = Input.Vertical()*speed;
       

        muv.Muvet(vec);
        muv.Rotat(vec, Camer);
        
    }



}

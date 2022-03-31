using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class GeneralManedjer : MonoBehaviour
{
    public static GeneralManedjer GenerM;  
    public int GenResurs;
    [SerializeField] Text Resurs_3;
    void Start()
    {
        GenerM = this;
     
    }

    // Update is called once per frame
    void Update()
    {
        Resurs_3.text = GenResurs.ToString();
    }
}

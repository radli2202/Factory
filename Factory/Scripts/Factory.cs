using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : FactoryAbstract
{
   
    void Start()
    {
        Startin();
        StartCoroutine(Worcking());
    }

 
    IEnumerator Worcking()
    {
        yield return new WaitForSeconds(2f);
        CreatResurs(); 
        StartCoroutine(Worcking());
        yield break;
    }

 



 
}

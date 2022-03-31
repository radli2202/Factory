using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Factory_3 : MonoBehaviour
{
    [SerializeField] int res_1, res_2;

    [SerializeField] GeneralManedjer Gen;
    bool woc => res_1 > 0 && res_2 > 0;
    void Start()
    {
        Gen = Gen.GetComponent<GeneralManedjer>();
        StartCoroutine(Worcking());
    }

    IEnumerator Worcking()
    {
        yield return new WaitForSeconds(1f);
        if (woc)
        {
            res_1--; res_2--; 
            Gen.GenResurs++;
        }
        StartCoroutine(Worcking());
        yield break;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<Character>().Resurs_1 >= 1) Cycle_1(other.gameObject);

            if (other.gameObject.GetComponent<Character>().Resurs_2 >= 1) Cycle_2(other.gameObject);

        }
    }


    void Cycle_1(GameObject p)
    {
        do
        {
            p.gameObject.GetComponent<Character>().Resurs_1--;
            res_1++;
        }
        while (p.gameObject.GetComponent<Character>().Resurs_1 >= 1);
    }
    void Cycle_2(GameObject p)
    {
        do
        {
            p.gameObject.GetComponent<Character>().Resurs_2--;
            res_2++;
        }
        while (p.gameObject.GetComponent<Character>().Resurs_2 >= 1);

    }


}

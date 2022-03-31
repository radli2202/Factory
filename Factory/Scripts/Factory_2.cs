using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory_2 : FactoryAbstract
{

    public int Res,Genres;


    void Start()
    {
        Startin();
        StartCoroutine(Worcking());
    }


    IEnumerator Worcking()
    {
        yield return new WaitForSeconds(1f);
        if (Res > 0)
        {
            CreatResurs();
            
            Res--;
            Genres++;
        }
        StartCoroutine(Worcking());
        yield break;
    }
    public override void GetPlayer(GameObject player)
    {
        if (player.GetComponent<Character>().Resurs_2 < 3)
        {
            do
            {
                
                player.GetComponent<Character>().Resurs_2++;
                GetResurs();
            }
            while (player.GetComponent<Character>().Resurs_2 < 3);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (other.gameObject.GetComponent<Character>().Resurs_1 >= 1)
            {
                do
                {
                    other.gameObject.GetComponent<Character>().Resurs_1--;
                    Res++;
                }
                while (other.gameObject.GetComponent<Character>().Resurs_1 >= 1);


            }

            if (other.gameObject.GetComponent<Character>().Resurs_2 < 3)
            {
                if (Genres > 0) { GetPlayer(other.gameObject); }
            }
                



        }
    }
}

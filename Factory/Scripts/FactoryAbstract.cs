using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FactoryAbstract : MonoBehaviour
{
    [SerializeField] public GameObject Resurs;
    [SerializeField] Transform Point;
    [SerializeField] int Limit;
    List<GameObject> _list;



    [SerializeField] int xSize, ySize, zSize;    
    GameObject[,,] tiles;
    int in_stock;

    Vector3 offset;
    
    bool MaxLimit => in_stock >= Limit;


    public virtual void CreatResurs()
    {
        if (!MaxLimit)
        {
            _list[in_stock].SetActive(true);

            if (_list[in_stock].active) in_stock++;

        }
      
    }

    public void GetResurs()
    {

        if (in_stock >= 0)
        {
            _list[in_stock - 1].SetActive(false);
            in_stock--;

        }
        

    }

   public void Startin()
    {
        _list = new List<GameObject>();
        offset = Resurs.GetComponent<Transform>().localScale;
        CreateBoard(offset.x, offset.y, offset.z);
        Point = Point.GetComponent<Transform>();
        
    }

    private void CreateBoard(float xOffset, float yOffset, float zOffset)
    {
        tiles = new GameObject[xSize, ySize, zSize];    
        float startX = Point.position.x;    
        float startY = Point.position.y;
        float startZ = Point.position.z;

        for (int x = 0; x < xSize; x++)
        {     
            for (int y = 0; y < ySize; y++)
            {
                for (int z = 0; z < zSize; z++)
                {
                    GameObject newTile = Instantiate(Resurs, new Vector3(startX + (xOffset * x), startY + (yOffset * y), startZ + (zOffset * z)), Resurs.transform.rotation);
                    tiles[x, y, z] = newTile;
                    newTile.transform.parent = Point;
                    newTile.SetActive(false);
                    _list.Add(newTile);
                }
            }
        }
    }

    public virtual void GetPlayer(GameObject player)
    {
        if (player.GetComponent<Character>().Resurs_1 < 3)
        {
            do
            {
                player.GetComponent<Character>().Resurs_1++;
                GetResurs();
            }
            while (player.GetComponent<Character>().Resurs_1 < 3);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (in_stock >= 0)
            {
                GetPlayer(other.gameObject);

            }
           
        }
    }
}

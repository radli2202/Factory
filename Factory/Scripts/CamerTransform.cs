using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerTransform : MonoBehaviour
{
    [SerializeField] Transform Player;
    Transform ThisTr;
    void Start()
    {
        ThisTr = GetComponent<Transform>();
        Player = Player.GetComponent<Transform>();
    }

   
    void Update()
    {
        ThisTr.position = Player.position;
    }
}

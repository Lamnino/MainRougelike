using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsWall : MonoBehaviour
{
    public int rand;
    private void Awake()
    {
        rand = Random.Range(0, 3);
    }
}

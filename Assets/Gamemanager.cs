using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    private  static Gamemanager singleton;
    public static Gamemanager Singleton 
    { 
        get => singleton;
        set
        {
            if (singleton == null) singleton = value;
        }
    }
    public int rand;
    private void Start()
    {
        Singleton = this;
        rand = Random.Range(0, 2);
    }
}

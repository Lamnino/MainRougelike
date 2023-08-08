using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMap : MonoBehaviour
{
    public static ManagerMap singleton;
    [SerializeField] int level;
    [SerializeField] public int numtype;
    public bool isstart;
    public int width = 0;
    public int height = 0;
    private void Awake()
    {
        singleton = this;
        isstart = true;
        width = level *5;
        height = level * 3;
    }
    private void Start()
    {
    }

}

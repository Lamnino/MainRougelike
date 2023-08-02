using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StartRandomMap : MonoBehaviour
{
    int maxX = 50;
    int maxY = 40;
    Transform[] StarPoint;
    GameObject[] ListMap = new GameObject[100];
    public GameObject character;
    // Start is called before the first frame update
    private void Start()
    {
        int numstar = UnityEngine.Random.Range(0, 4);
        transform.position = new Vector3(14 * numstar, 7, 0);
        Transform starMap = option.instance.GetMapWithNum(transform, 4);
        ListMap[0] = starMap.gameObject;
        SpawnMap(ListMap, 1, starMap, -1);
        Instantiate(character, starMap.position + new Vector3(0,-2,0),Quaternion.identity);
    }
    public void SpawnMap(GameObject[] listMap, int k,Transform CurrMap, int oldGate)
    {
        int og =0;
        RandomMap Gates = CurrMap.gameObject.GetComponent<RandomMap>();
       for (int i=0; i< Gates.gate.Length; i++)
        {
            if (Gates.gate[i] != oldGate)
            {
                if (Gates.gate[i] == 1) og = 3; 
                if (Gates.gate[i] == 2) og = 4; 
                if (Gates.gate[i] == 3) og = 1; 
                if (Gates.gate[i] == 4) og = 2;
                GameObject newMap;
                try
                {
                    newMap = option.instance.GetMapWithNum(CurrMap, Gates.gate[i]).gameObject;
                    ListMap[k] = newMap;
                    SpawnMap(ListMap, k + 1, newMap.transform, og);
                }
                catch (Exception ex)
                {
                    Debug.Log(ex);
                }
            }
        }
    }
    
}

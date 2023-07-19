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
    // Start is called before the first frame update
    private void Start()
    {
        int numstar = UnityEngine.Random.Range(0, 5);
        transform.position = new Vector3(14 * numstar, 8, 0);
        Transform starMap = option.instance.GetMapWithNum(transform, 4);
        ListMap[0] = starMap.gameObject;
        SpawnMap(ListMap, 1, starMap, -1);
    }
    public void SpawnMap(GameObject[] listMap, int k,Transform CurrMap, int oldGate)
    {
        int og =0;
        RandomMap Gates = CurrMap.gameObject.GetComponent<RandomMap>();
       for (int i=0; i< Gates.gate.Length; i++)
        {
            Debug.Log(Gates.gate[i]);
            if (Gates.gate[i] != oldGate)
            {
                if (Gates.gate[i] == 1) og = 3; 
                if (Gates.gate[i] == 2) og = 4; 
                if (Gates.gate[i] == 3) og = 1; 
                if (Gates.gate[i] == 4) og = 2;
                if (Gates.gate[i] == 1 && CurrMap.position.x <= 0) return;
                if (Gates.gate[i] == 4 && CurrMap.position.y <= 0) return;
                if (Gates.gate[i] == 3 && CurrMap.position.x >= maxX) return;
                if (Gates.gate[i] == 2 && CurrMap.position.y >= maxY) return;
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

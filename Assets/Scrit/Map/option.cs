using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class option : MonoBehaviour
{
    public static option instance;
    GameObject newmap;
    RandomMap script;
    public GameObject[] above;
    public GameObject[] Right;
    public GameObject[] Left;
    public GameObject[] bottom;
    Transform[] Road = new Transform[30];
    Transform newMap;
    int rdn;
    int maxX =30;
    int maxY = 20;

    private void Start()
    {
        instance = this;
    }
    public Transform GetMapWithNum(Transform ObviouMap, int num)
    {
        if (num == 1 && ObviouMap.position.x <= 0) return null;
        if (num == 4 && ObviouMap.position.y <= 0) return null;
        if (num == 3 && ObviouMap.position.x >= maxX) return null;
        if (num == 2 && ObviouMap.position.y >= maxY) return null;
        switch (num)
        {
            case 1:
                rdn = Random.Range(0,Right.Length-1);
                newMap = Instantiate(Right[rdn], ObviouMap.position + new Vector3(-14, 0,0), Quaternion.identity, transform).transform;
                break;
            case 2:
                rdn = Random.Range(0, bottom.Length-1);
                newMap = Instantiate(bottom[rdn], ObviouMap.position + new Vector3(0, 7,0), Quaternion.identity, transform).transform;
                break;
            case 3:
                rdn = Random.Range(0, Left.Length - 1);
                newMap = Instantiate(Left[rdn], ObviouMap.position + new Vector3(14, 0, 0), Quaternion.identity, transform).transform;
                break;
            case 4:
                rdn = Random.Range(0, above.Length - 1);
                newMap = Instantiate(above[rdn], ObviouMap.position + new Vector3(0, -7, 0), Quaternion.identity, transform).transform;
                break;
        }
        int j = 0;
        while (Road[j] != null)
        {
            if (newMap.position == Road[j].position)
            {
                Destroy(newMap.gameObject);
                return null;
            }
            j++;
        }
        Road[j] = newMap;
        return newMap;
    }
    public int OptionGateNum(int NumGate)
    {
        if (NumGate == 1) return above.Length;
        return 0;
    }
    
}

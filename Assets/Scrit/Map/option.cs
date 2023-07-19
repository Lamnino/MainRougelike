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
    public Transform[] Road = new Transform[100];
    Transform newMap;
    int rdn;

    private void Start()
    {
        instance = this;
    }
    public Transform GetMapWithNum(Transform ObviouMap, int num)
    {
        switch (num)
        {
            case 1:
                rdn = Random.Range(0,Right.Length-1);
                newMap = Instantiate(Right[rdn], ObviouMap.position + new Vector3(-14, 0,0), Quaternion.identity, transform).transform;
                break;
            case 2:
                rdn = Random.Range(0, bottom.Length-1);
                newMap = Instantiate(bottom[rdn], ObviouMap.position + new Vector3(0, 8,0), Quaternion.identity, transform).transform;
                break;
            case 3:
                rdn = Random.Range(0, Left.Length - 1);
                newMap = Instantiate(Left[rdn], ObviouMap.position + new Vector3(14, 0, 0), Quaternion.identity, transform).transform;
                break;
            case 4:
                rdn = Random.Range(0, above.Length - 1);
                newMap = Instantiate(above[rdn], ObviouMap.position + new Vector3(0, -8, 0), Quaternion.identity, transform).transform;
                break;
        }
        int j = 0;
        while (Road[j] !=null)
        {
            if (newMap.position == Road[j].position)
            {
                Debug.Log(Road[j]);
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
    //case -1:
    //            rdn = Random.Range(0, above.Length-1);
    //            Debug.Log("yes");
    //            GameObject newmap11 = Instantiate(above[rdn], obvious);
    //RandomMap script = newmap11.GetComponent<RandomMap>();
    //script.SpawnNextMap(-1);
    //            break;

    //        case 1:
    //            rdn = Random.Range(0, Right.Length-1);
    //            GameObject newmap1 = Instantiate(Right[rdn], obvious.position + new Vector3(-12, 0, 0), Quaternion.identity, transform);
    //script= newmap1.GetComponent<RandomMap>();
    //            script.SpawnNextMap(3);
    //            break;
    //        case 2:
    //            rdn = Random.Range(0, bottom.Length-1);
    //            GameObject newmap2 = Instantiate(bottom[rdn], obvious.position + new Vector3(0, 8, 0), Quaternion.identity, transform);
    //script = newmap2.GetComponent<RandomMap>();
    //            script.SpawnNextMap(4);
    //            break;
    //        case 3:
    //            rdn = Random.Range(0, Left.Length-1);
    //            GameObject newmap3 = Instantiate(Left[rdn], obvious.position + new Vector3(12, 0, 0), Quaternion.identity, transform);
    //script = newmap3.GetComponent<RandomMap>();
    //            script.SpawnNextMap(1);
    //            break;
    //        case 4:
    //            rdn = Random.Range(0, above.Length-1);
    //            GameObject newmap4 = Instantiate(above[rdn], obvious.position + new Vector3(0, -8, 0), Quaternion.identity, transform);
    //script = newmap4.GetComponent<RandomMap>();
    //            script.SpawnNextMap(2);
    //            break;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

public class option : MonoBehaviour
{
    public static option instance;
    GameObject newmap;
    RandomMap script;
    public GameObject[] A1;
    public GameObject[] A2;
    public GameObject[] A3;
    public GameObject[] A4;
    public GameObject[] C1;
    public GameObject[] C2;
    public GameObject[] C3;
    public GameObject[] C4;
    public GameObject[] C5;
    public GameObject[] C6;
    public GameObject[] C7;
    public GameObject[] C8;
    public GameObject[] Start;
    Transform[] Road = new Transform[30];
    int maparray = 0;
    Vector3 NewPos;
    int rdn;
    private void Awake()
    {
        instance = this;
    }
    public void StartMap(Vector3 ObviouMap)
    {
        Transform newMap;
        int rand = UnityEngine.Random.Range(1, Start.Length);
                newMap = Instantiate(Start[rand], ObviouMap, Quaternion.identity, transform).transform;
                
        RandomMap randMapComponent = newMap.GetComponent<RandomMap>();
        for (int i = 0; i < randMapComponent.gate.Length; i++)
        {
            randMapComponent.RandomType(0);
        }
    }
    private void addroad(Vector3 pos)
    {
        int i = 0;
        while (RandomMap.Road[i] != new Vector3(0,0,-1))
        {
            i++;
        }
        RandomMap.Road[i] = pos;
    }
    public void GetMap(int typeMap,int posOption, Vector3 PreviousPos,int gate, char TypeMapPrevious)
    {
        GameObject[] array = TypeMapByName(typeMap, TypeMapPrevious, PreviousPos, gate, posOption);
        int random = UnityEngine.Random.Range(0, array.Length);
        Instantiate(array[random], NewPos, Quaternion.identity, transform).GetComponent<RandomMap>().RandomType(maparray);
    }
    private GameObject[] TypeMapByName(int TypeMap, char TypeMapPrevious, Vector3 PreviousPos, int gate, int posOption)
    {

        if (TypeMapPrevious == 'A')
        {
            if (TypeMap == 1)
            {
                switch (gate)
                {
                    case 1:
                        maparray = 3;
                        NewPos = newPos(PreviousPos, 0, 8);
                        break;
                    case 2:
                        maparray = 4;
                        NewPos = newPos(PreviousPos, 14, 0);
                        break;
                    case 3:
                        maparray = 1;
                        NewPos = newPos(PreviousPos, 0, -8);
                        break;
                    case 4:
                        maparray = 2;
                        NewPos = newPos(PreviousPos, -14, 0);
                        break;
                }
                addroad(NewPos);
            }
            else
            {
                if (posOption != 0) maparray = posOption;
                else
                {
                    if (gate == 1) maparray = UnityEngine.Random.Range(5, 6);
                    if (gate == 2) maparray = UnityEngine.Random.Range(7, 8);
                    if (gate == 3) maparray = UnityEngine.Random.Range(1, 2);
                    if (gate == 4) maparray = UnityEngine.Random.Range(3, 4);
                }
                switch (maparray)
                {
                    case 1:
                        NewPos = newPos(PreviousPos, 7, -12);
                        break;
                    case 2:
                        NewPos = newPos(PreviousPos, -7, -12);
                        break;
                    case 3:
                        NewPos = newPos(PreviousPos, -21, -4);
                        break;
                    case 4:
                        NewPos = newPos(PreviousPos, -21, 4);
                        break;
                    case 5:
                        NewPos = newPos(PreviousPos, -7, 12);
                        break;
                    case 6:
                        NewPos = newPos(PreviousPos, 7, 12);
                        break;
                    case 7:
                        NewPos = newPos(PreviousPos, 21, 4);
                        break;
                    case 8:
                        NewPos = newPos(PreviousPos, 21, -4);
                        break;
                }
                addroad(NewPos + new Vector3(-7, 4, 0));
                addroad(NewPos + new Vector3(7, 4, 0));
                addroad(NewPos + new Vector3(7, -4, 0));
                addroad(NewPos + new Vector3(-7, -4, 0));
            }
        }
        else if (TypeMapPrevious == 'C')
        {
            if (TypeMap == 1)
            {
                switch (gate)
                {
                    case 1:
                        maparray = 3;
                        NewPos = newPos(PreviousPos, -7, 12);
                        break;
                    case 2:
                        maparray = 3;
                        NewPos = newPos(PreviousPos, 7, 12);
                        break;
                    case 3:
                        maparray = 4;
                        NewPos = newPos(PreviousPos, 21, 4);
                        break;
                    case 4:
                        maparray = 4;
                        NewPos = newPos(PreviousPos, 21, -4);
                        break;
                    case 5:
                        maparray = 1;
                        NewPos = newPos(PreviousPos, 7, -12);
                        break;
                    case 6:
                        maparray = 1;
                        NewPos = newPos(PreviousPos, -7, -12);
                        break;
                    case 7:
                        maparray = 2;
                        NewPos = newPos(PreviousPos, -21, -4);
                        break;
                    case 8:
                        maparray = 2;
                        NewPos = newPos(PreviousPos, -21, 4);
                        break;
                }
                addroad(NewPos);
            }
            else
            {
                if (posOption != 0) maparray = posOption;
                else
                {
                    if (gate == 1 || gate == 2) maparray = UnityEngine.Random.Range(5, 6);
                    if (gate == 3 || gate == 4) maparray = UnityEngine.Random.Range(7, 8);
                    if (gate == 5 || gate == 6) maparray = UnityEngine.Random.Range(1, 2);
                    if (gate == 7 || gate == 8) maparray = UnityEngine.Random.Range(3, 4);
                }
                switch (gate)
                {
                    case 1:
                        if (maparray == 5)
                            NewPos = newPos(PreviousPos, -14, 16);
                        else 
                            if (maparray == 6)
                            NewPos = newPos(PreviousPos, 0, 16);
                        break;
                    case 2:
                        if (maparray == 6)
                            NewPos = newPos(PreviousPos, 14, 16);
                        else
                            if (maparray == 5)
                            NewPos = newPos(PreviousPos, 0, 16);
                        break;
                    case 3:
                        if (maparray == 7)
                            NewPos = newPos(PreviousPos, 28, 8);
                        else
                            if (maparray == 8)
                            NewPos = newPos(PreviousPos, 28, 0);
                        break;
                    case 4:
                        if (maparray == 7)
                            NewPos = newPos(PreviousPos, 28, 0);
                        else
                            if (maparray == 8)
                            NewPos = newPos(PreviousPos, 28, -8);
                        break;
                    case 5:
                        if (maparray == 1)
                            NewPos = newPos(PreviousPos, 14, -16);
                        else
                             if (maparray == 6)
                            NewPos = newPos(PreviousPos, 0, -16);
                        break;
                    case 6:
                        if (maparray == 1)
                            NewPos = newPos(PreviousPos, 0, -16);
                        else
                            if (maparray == 2)
                            NewPos = newPos(PreviousPos, -14, -16);
                        break;
                    case 7:
                        if (maparray == 3)
                            NewPos = newPos(PreviousPos, -28, -8);
                        else
                            if (maparray == 4)
                            NewPos = newPos(PreviousPos, -28, 0);
                        break;
                    case 8:
                        if (maparray == 3)
                            NewPos = newPos(PreviousPos, -28, 0);
                        else
                            if (maparray == 4)
                            NewPos = newPos(PreviousPos, -28, 8);
                        break;
                }
                addroad(NewPos + new Vector3(-7, 4, 0));
                addroad(NewPos + new Vector3(7, 4, 0));
                addroad(NewPos + new Vector3(7, -4, 0));
                addroad(NewPos + new Vector3(-7, -4, 0));
            }
        }
            string opTypeArray = "";
        if (TypeMap == 1) opTypeArray = "A";
        else opTypeArray = "C";
        string arrayName = $"{opTypeArray}{maparray}";
        Type type = typeof(option);
        FieldInfo field = type.GetField(arrayName);
        return (GameObject[])field.GetValue(this);
    }
    
    private Vector3 newPos(Vector3 PreviousPos, int x, int y)
    {
        return PreviousPos + new Vector3(x, y, 0);
    }

        //private Vector3 PositionNewMap(int PreviousTypeMap, Vector3 PreviousPos, int TypeMap, int gate)
        //{
        //    if (PreviousTypeMap == 1)
        //    {
        //        if (TypeMap == 1)
        //        {
        //            switch (gate)
        //            {
        //                case 1: return newPos(PreviousPos, 0, 8);
        //                case 2: return newPos(PreviousPos, 14, 0);
        //                case 3: return newPos(PreviousPos, 0, -8);
        //                case 4: return newPos(PreviousPos, -14, 0);
        //                default: return Vector3.zero; ;
        //            }
        //        }
        //        else if (TypeMap == 3)
        //        {
        //            switch (gate)
        //            {
        //                case 1: return newPos(PreviousPos, 7, 12);
        //                case 2: return newPos(PreviousPos, -7, 12);
        //                case 3: return newPos(PreviousPos, 21, -4);
        //                case 4: return newPos(PreviousPos, 21, 4);
        //                case 4: return newPos(PreviousPos, 7, 12);
        //                case 4: return PreviousPos + new Vector3(-14, 0, 0);
        //                case 4: return PreviousPos + new Vector3(-14, 0, 0);
        //                case 4: return PreviousPos + new Vector3(-14, 0, 0);
        //                default: return Vector3.zero;
        //            }
        //        }

        //    }
        //}

        //public Transform GetMapWithNum(Vector3 ObviouMap, int num)
        //{
        //    if (num == 1 && ObviouMap.x <= 0) return null;
        //    if (num == 4 && ObviouMap.y <= 0) return null;
        //    if (num == 3 && ObviouMap.x >= maxX) return null;
        //    if (num == 2 && ObviouMap.y >= maxY) return null;
        //    switch (num)
        //    {
        //        case 1:
        //            rdn = Random.Range(0,Right.Length-1);
        //            newMap = Instantiate(Right[rdn], ObviouMap + new Vector3(-14, 0,0), Quaternion.identity, transform).transform;
        //            break;
        //        case 2:
        //            rdn = Random.Range(0, bottom.Length-1);
        //            newMap = Instantiate(bottom[rdn], ObviouMap + new Vector3(0, 7,0), Quaternion.identity, transform).transform;
        //            break;
        //        case 3:
        //            rdn = Random.Range(0, Left.Length - 1);
        //            newMap = Instantiate(Left[rdn], ObviouMap + new Vector3(14, 0, 0), Quaternion.identity, transform).transform;
        //            Debug.Log(rdn);
        //            break;
        //        case 4:
        //            rdn = Random.Range(0, above.Length - 1);
        //            newMap = Instantiate(above[rdn], ObviouMap + new Vector3(0, -7, 0), Quaternion.identity, transform).transform;
        //            break;
        //    }
        //    int j = 0;
        //    while (Road[j] != null)
        //    {
        //        if (newMap.position == Road[j].position)
        //        {
        //            Destroy(newMap.gameObject);
        //            return null;
        //        }
        //        j++;
        //    }
        //    Road[j] = newMap;
        //    return newMap;
        //}
        //public int OptionGateNum(int NumGate)
        //{
        //    if (NumGate == 1) return above.Length;
        //    return 0;
        //}

    }

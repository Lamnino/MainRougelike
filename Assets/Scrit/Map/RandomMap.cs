using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMap : MonoBehaviour
{
    public int[] gate;
    public char Typeofmap;
    int posoption = 0;
    //public string option;
    private int i;
    public static Vector3[] Road = new Vector3[100];
    private void Start()
    {
        for (int i =0;i<100; i++)
        {
            Road[i] = new Vector3(0, 0, -1);
        }
        if (ManagerMap.singleton.isstart)
        {
            ManagerMap.singleton.isstart = false;
            StartRandom();
        }
    }
    public void RandomType(int GateConnected)
    {
        for (int i=0; i<gate.Length; i++)
        { 
            if (gate[i] != GateConnected)
            {
                int NextTypeMap = RandType(gate[i]);
                if (NextTypeMap != 0)
                {
                    option.instance.GetMap(NextTypeMap, posoption, transform.position, gate[i], Typeofmap);
                }
            }
        }
    }
    private int RandType(int gate)
    {
        if (Typeofmap == 'A')
        {
            // Check Area
            if ((gate) == 2 && checkArar(transform.position + new Vector3(14, 0))
                    || (gate) == 4 && checkArar(transform.position + new Vector3(-14, 0))
                    || (gate) == 1 && checkArar(transform.position + new Vector3(0, 8))
                    || (gate) == 3 && checkArar(transform.position + new Vector3(0, -8))
            || (gate) == 2 && transform.position.x > ManagerMap.singleton.width * 14 - 14
            || (gate) == 4 && transform.position.x < 14
            || (gate) == 1 && transform.position.y > ManagerMap.singleton.height * 8 - 8
            || (gate) == 3 && transform.position.y < 8)
            {
                return 0;
            }
            //A ok so check C
            //check limit position
            if (gate == 2 && transform.position.x > ManagerMap.singleton.width * 14 - 28
                || gate == 4 && transform.position.x < 28
                || gate == 1 && transform.position.y > ManagerMap.singleton.height * 8 - 16
                || gate == 3 && transform.position.y < 16)
            {
                return 1;
            }
            //Check Area
            bool check2 = true;
            bool check1 = true;
            if (gate == 2)
            {
                if (checkArar(transform.position + new Vector3(14, -8))
                || checkArar(transform.position + new Vector3(28, -8))
                || transform.position.y -8 < 0) check2 = false;
                if (checkArar(transform.position + new Vector3(28, 0))) return 1;
                if (checkArar(transform.position + new Vector3(14, 8))
                 || checkArar(transform.position + new Vector3(28, 8))
                 || transform.position.y + 8 > ManagerMap.singleton.height * 8) check1 = false;
                if (check1 && check2) posoption = 0;
                else
                if (check1) posoption = 7;
                else
                if (check2) posoption = 8;
                else
                    return 1;
            }
            else if (gate == 4)
            {
                if (checkArar(transform.position + new Vector3(-14, -8))
                || checkArar(transform.position + new Vector3(-28, -8))
                || transform.position.y - 8 < 0 ) check2 = false;
                if (checkArar(transform.position + new Vector3(-28, 0))) return 1;
                if (checkArar(transform.position + new Vector3(-14, 8))
                 || checkArar(transform.position + new Vector3(-28, 8))
                 || transform.position.y + 8 > ManagerMap.singleton.height * 8) check1 = false;
                if (check1 && check2) posoption = 0;
                else
                if (check1) posoption = 4;
                else
                if (check2) posoption = 3;
                else
                    return 1;
            }
            else if (gate == 1)
            {
                if (checkArar(transform.position + new Vector3(-14, 8))
                || checkArar(transform.position + new Vector3(-14, 16))
                || transform.position.x - 14 < 0) check1 = false;
                if (checkArar(transform.position + new Vector3(0, 16))) return 1;
                if (checkArar(transform.position + new Vector3(14, 8))
                 || checkArar(transform.position + new Vector3(14, 16))
                 || transform.position.x + 14 > ManagerMap.singleton.width * 14) check2 = false;
                if (check1 && check2) posoption = 0;
                else
                if (check1) posoption = 5;
                else
                if (check2) posoption = 6;
                else
                    return 1;
            }
            else if (gate == 3)
            {
                if (checkArar(transform.position + new Vector3(-14, -8))
                || checkArar(transform.position + new Vector3(-14, -16))
                || transform.position.x - 14 < 0) check1 = false;
                if (checkArar(transform.position + new Vector3(0, -16))) return 1;
                if (checkArar(transform.position + new Vector3(14, -8))
                 || checkArar(transform.position + new Vector3(14, -16))
                 || transform.position.x + 14 > ManagerMap.singleton.width * 14) check2 = false;
                if (check1 && check2) posoption = 0;
                else
                if (check1) posoption = 2;
                else
                if (check2) posoption = 1;
                else
                    return 1;
            }
        }
        else if (Typeofmap == 'C')
        {
            if ((gate) == 1 && checkArar(transform.position + new Vector3(-7, 12))
                   || (gate) == 2 && checkArar(transform.position + new Vector3(7, 12))
                   || (gate) == 3 && checkArar(transform.position + new Vector3(21, 4))
                   || (gate) == 4 && checkArar(transform.position + new Vector3(21, -4))
                   || (gate) == 5 && checkArar(transform.position + new Vector3(7, -12))
                   || (gate) == 6 && checkArar(transform.position + new Vector3(-7, -12))
                   || (gate) == 7 && checkArar(transform.position + new Vector3(-21, -4))
                   || (gate) == 8 && checkArar(transform.position + new Vector3(-21, 4))
           || direct(gate) == 2 && transform.position.x > ManagerMap.singleton.width * 14 - 21
           || direct(gate) == 4 && transform.position.x < 21
           || direct(gate) == 1 && transform.position.y > ManagerMap.singleton.height * 8 - 12
           || direct(gate) == 3 && transform.position.y <12)
            {
                return 0;
            }
            //A ok so check C
            //check limit position
            if (direct(gate) == 2 && transform.position.x > ManagerMap.singleton.width * 14 - 35
                || direct(gate) == 4 && transform.position.x < 35
                || direct(gate) == 1 && transform.position.y > ManagerMap.singleton.height * 8 - 20
                || direct(gate) == 3 && transform.position.y < 20)
            {
                return 1;
            }
            //Check Area
            int test = 0;
            switch (gate)
            {
                case 1:
                    test = CheckRandom(transform.position + new Vector3(-7, 4), 1);
                    break;
                case 2:
                    test = CheckRandom(transform.position + new Vector3(7, 4), 1);
                    break;
                case 3:
                    test = CheckRandom(transform.position + new Vector3(7, 4), 2);
                    break;
                case 4:
                    test = CheckRandom(transform.position + new Vector3(7, -4), 2);
                    break;
                case 5:
                    test = CheckRandom(transform.position + new Vector3(7, -4), 3);
                    break;
                case 6:
                    test = CheckRandom(transform.position + new Vector3(-7, -4), 3);
                    break;
                case 7:
                    test = CheckRandom(transform.position + new Vector3(7, -4), 4);
                    break;
                case 8:
                    test = CheckRandom(transform.position + new Vector3(7, 4), 4);
                    break;
            }
            if (test == 0 || test == 1) return test;
        }
        int vl = Random.Range(1, ManagerMap.singleton.numtype+3);
        return vl;
    }

    private int CheckRandom(Vector3 position, int gate)
    {
        bool check2 = true;
        bool check1 = true;
        if (gate == 1)
        {
            if (checkArar(transform.position + new Vector3(-14, 8))
            || checkArar(transform.position + new Vector3(-14, 16))
            || transform.position.x - 28 < 0) check1 = false;
            if (checkArar(transform.position + new Vector3(0, 16))) return 1;
            if (checkArar(transform.position + new Vector3(14, 8))
             || checkArar(transform.position + new Vector3(14, 16))
             || transform.position.x + 28 > ManagerMap.singleton.width * 14) check2 = false;
            if (check1 && check2) posoption = 0;
            else
            if (check1) posoption = 5;
            else
            if (check2) posoption = 6;
            else
                return 1;
        }
        else
         if (gate == 2)
        {
            if (checkArar(transform.position + new Vector3(14, -8))
            || checkArar(transform.position + new Vector3(28, -8))
            || transform.position.y - 16 < 0) check2 = false;
            if (checkArar(transform.position + new Vector3(28, 0))) return 1;
            if (checkArar(transform.position + new Vector3(14, 8))
             || checkArar(transform.position + new Vector3(28, 8))
             || transform.position.y + 16 > ManagerMap.singleton.height * 8) check1 = false;
            if (check1 && check2) posoption = 0;
            else
            if (check1) posoption = 7;
            else
            if (check2) posoption = 8;
            else
                return 1;
        }
        else if (gate == 4)
        {
            if (checkArar(transform.position + new Vector3(-14, -8))
            || checkArar(transform.position + new Vector3(-28, -8))
            || transform.position.y - 16 < 0) check2 = false;
            if (checkArar(transform.position + new Vector3(-28, 0))) return 1;
            if (checkArar(transform.position + new Vector3(-14, 8))
             || checkArar(transform.position + new Vector3(-28, 8))
             || transform.position.y + 16 > ManagerMap.singleton.height * 8) check1 = false;
            if (check1 && check2) posoption = 0;
            else
            if (check1) posoption = 4;
            else
            if (check2) posoption = 3;
            else
                return 1;
        }
        else if (gate == 3)
        {
            if (checkArar(transform.position + new Vector3(-14, -8))
            || checkArar(transform.position + new Vector3(-14, -16))
            || transform.position.x - 28 < 0) check1 = false;
            if (checkArar(transform.position + new Vector3(0, -16))) return 1;
            if (checkArar(transform.position + new Vector3(14, -8))
             || checkArar(transform.position + new Vector3(14, -16))
             || transform.position.x + 28 > ManagerMap.singleton.width * 14) check2 = false;
            if (check1 && check2) posoption = 0;
            else
            if (check1) posoption = 2;
            else
            if (check2) posoption = 1;
            else
                return 1;
        }
        return 200;
    }
    private bool checkArar(Vector3 pos)
    {
        int i = 0;
        while (Road[i] != new Vector3(0,0,-1))
        {
            if (pos == Road[i]) return true;
            i++;
        }
        return false;
    }
    private int direct(int gate)
    {
        if (Typeofmap == 'A')
            return gate;
        else
        if (Typeofmap == 'C')
            return (gate-1) / 2 + 1;
        return 0;
    }
    [SerializeField] GameObject fill;
    private void StartRandom()
    {
        int PosStart = Random.Range(2, ManagerMap.singleton.width);
        Road[0] = transform.position + new Vector3((PosStart - 1) * 14, 0, 0);
        option.instance.StartMap(Road[0]);
        int y = -7;
        for (int i = -1; i <= ManagerMap.singleton.width + 1;i++) 
        {
            Instantiate(fill, new Vector3(i * 14, y, 0), Quaternion.identity, transform);
        }
        y = (ManagerMap.singleton.height+1)*8 ;
        for (int i = -1; i <= ManagerMap.singleton.width + 1; i++) 
        {
            Instantiate(fill, new Vector3(i * 14, y, 0), Quaternion.identity, transform);
        }
        int x = -14;
        for (int i = 0; i <= ManagerMap.singleton.height ; i++)
        {
            Instantiate(fill, new Vector3(x, i*8, 0), Quaternion.identity, transform);
        }
        x = (ManagerMap.singleton.width+1) * 14 ;
        for (int i = 0; i <= ManagerMap.singleton.height; i++)
        {
            Instantiate(fill, new Vector3(x, i * 8 , 0), Quaternion.identity, transform);
        }
        for (int i = 0; i<= ManagerMap.singleton.width; i++)
        {
            for (int j =0; j<= ManagerMap.singleton.height; j++)
            {
                Vector3 filpos = new Vector3(i * 14, j * 8, 0);
                if (!checkArar(filpos))
                {
                    Instantiate(fill, filpos, Quaternion.identity, transform);
                }
            }
        }
    }


}
                        
        
        

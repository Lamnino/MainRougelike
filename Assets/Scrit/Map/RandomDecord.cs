using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDecord : MonoBehaviour
{
    public GameObject[] ListPrefab;
    public Transform containwall;
    private void Start()
    {
        random();
    }
    void random()
    {
        int num = Random.Range(0, ListPrefab.Length);
        Instantiate(ListPrefab[num], containwall);
    }
}

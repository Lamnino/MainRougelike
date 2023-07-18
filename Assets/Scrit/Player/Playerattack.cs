using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerattack : MonoBehaviour
{
    public static Playerattack instance;
    public GameObject at1r;
    public GameObject at2r;
    public GameObject at3r;

    public GameObject at1l;
    public GameObject at2l;
    public GameObject at3l;

    private void Start()
    {
        instance = this;
    }
}

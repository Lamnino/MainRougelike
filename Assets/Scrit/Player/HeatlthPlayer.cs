using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatlthPlayer : MonoBehaviour
{
    public static HeatlthPlayer intance;
    [SerializeField] private int maxhealth;
    [SerializeField] private int health;
    private SpriteRenderer sp;

    void Start()
    {
        intance = this;
        health = maxhealth;
        sp = gameObject.GetComponent<SpriteRenderer>();
    }
   public void takeDame (int dame)
    {
        StartCoroutine(effectDame());
        health -= dame;
        if (health <= 0) Destroy(gameObject);
    }
    IEnumerator effectDame()
    {
        sp.color = Color.red;
        yield return new WaitForSeconds(1f);
        sp.color = Color.white;
    }
}

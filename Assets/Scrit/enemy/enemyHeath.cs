using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHeath : MonoBehaviour
{
    [SerializeField] private int MaxHealth;
    [SerializeField] private int health;
    [SerializeField] public bool allowDame = true;
    [SerializeField] public bool takeDamed = false;
    SpriteRenderer sp;

    private void Start()
    {
        health = MaxHealth;
        sp = gameObject.GetComponent<SpriteRenderer>();
    }

   

    public void TakeDame(int dame)
    {
        StartCoroutine(attackeffect());
            health -= dame;
            if (health <= 0)
                Destroy(gameObject);
    }
    IEnumerator attackeffect()
    {
        sp.color = new Color(255, 107, 0);
        yield return new WaitForSeconds(0.2f);
        sp.color = Color.white;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("character"))
        {
            if (allowDame)
            {
                HeatlthPlayer.intance.takeDame(10);
                allowDame = false;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("character"))
            allowDame = false;
    }
}

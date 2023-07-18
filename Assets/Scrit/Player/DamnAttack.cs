using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamnAttack : MonoBehaviour
{
    [SerializeField] public float dir;
    [SerializeField] private int damage = 20;
    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position+ new Vector3(dir,0,0), 0.54f, new Vector2(0,0 ));
        if (hit.collider != null && hit.collider.tag == "Enemy")
        {
            enemyHeath tdame = hit.collider.GetComponent<enemyHeath>();
            tdame.TakeDame(damage);
            gameObject.SetActive(false);
        }
    }
}

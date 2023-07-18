using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDame : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision was with an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Call the TakeDamage() method of the enemy and pass in the damage amount
            Bug enemy = collision.gameObject.GetComponent<Bug>();
            enemy.Damge(0.4f);
            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}

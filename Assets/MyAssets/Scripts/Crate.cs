using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    private int health;

    void Start()
    {
        health = 3;
    }

    public void TakeDamage()
    {
        health--;

        if (health == 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}

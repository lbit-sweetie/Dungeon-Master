using System;
using UnityEngine;

public class EHealthSystem : MonoBehaviour
{
    public float health;
    void Start()
    {

    }

    void Update()
    {

    }

    public void TakeDamage(float amout = 1)
    {
        health -= amout;
        if (health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Debug.Log("Dead");
        Destroy(gameObject);
    }
}
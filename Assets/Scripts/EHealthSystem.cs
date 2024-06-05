using System;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class EHealthSystem : MonoBehaviour
{
    public float health;
    public GameObject particles;

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
        Instantiate(particles, transform.position, Quaternion.identity);
        Debug.Log("Dead");
        Destroy(gameObject);
    }
}
using System;
using System.Collections;
using UnityEngine;

public class PAttack : MonoBehaviour
{
    public Camera _mainCamera;
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public float damage;

    public float delayDamage = 0.5f;

    private WaitForSeconds wait;
    private Coroutine damageCorutine = null;

    private void Start()
    {
        wait = new WaitForSeconds(delayDamage);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            GetDif();
            Attack();
        }
        else
        {
            animator.SetFloat("Dif", -1);
            if (damageCorutine != null)
                StopCoroutine(damageCorutine);
            damageCorutine = null;
        }
    }

    private void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        if (damageCorutine == null)
            damageCorutine = StartCoroutine(Damage(hitEnemies));
    }

    IEnumerator Damage(Collider2D[] hitEnemies)
    {
        while (true)
        {
            foreach (Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EHealthSystem>().TakeDamage(damage);
            }
            yield return wait;
        }
    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    private void GetDif()
    {
        Vector2 a = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 b = gameObject.transform.position;

        var dif = a - b;

        if (Mathf.Abs(dif.x) > Mathf.Abs(dif.y))
        {
            if (dif.x >= 0)
            {
                if (dif.x == 0)
                    dif.x = 0;
                else
                    dif.x = 1;
            }
            else
            {
                dif.x = -1;
            }
            dif.y = 0;
        }
        else
        {
            if (dif.y >= 0)
            {
                if (dif.y == 0)
                    dif.y = 0;
                else
                    dif.y = 1;
            }
            else
            {
                dif.y = -1;
            }
            dif.x = 0;
        }

        animator.SetFloat("Dif", 1);
        animator.SetFloat("HorA", dif.x);
        animator.SetFloat("VerA", dif.y);
    }
}
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public Transform pTransform;
    public float speed;
    public Animator animator;

    private Vector2 dirToPlayer;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector2 enemyToP = pTransform.position - transform.position;
        dirToPlayer = enemyToP.normalized;

        Debug.Log(dirToPlayer);
        rb.MovePosition(rb.position + dirToPlayer * speed * Time.deltaTime);
        animator.SetFloat("Horizontal", dirToPlayer.x);
        animator.SetFloat("Vertical", dirToPlayer.y);
        animator.SetFloat("Speed", dirToPlayer.sqrMagnitude);
    }
}

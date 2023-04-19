using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilverGuardians : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private GameObject player;
    [SerializeField] private CircleCollider2D circleColl;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private bool isGrounded = false;
    private Animator animat;
    public float damage;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        animat = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        Vector3 overlapCirclePosition = circleColl.transform.position;
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, 0.2f, groundMask);
    }
    private void Update()
    {
        if (isGrounded)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            animat.SetTrigger("isRun");
        }
        else
        {
            animat.SetTrigger("isFall");
        }
        MoveDirection();

    }
    public void Attack()
    {
        player.GetComponent<PlayerHealth>().TakeDamage(damage);
    }
    private void MoveDirection()
    {
        float moveDirection = player.transform.position.x - transform.position.x;
        if (moveDirection > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveDirection < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}

using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float attackCooldown = 2f;
    private float lastAttackTime = Mathf.NegativeInfinity;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && Time.time - lastAttackTime > attackCooldown)
        {
            anim.SetTrigger("isAttack");
            lastAttackTime = Time.time;
        }
    }
}

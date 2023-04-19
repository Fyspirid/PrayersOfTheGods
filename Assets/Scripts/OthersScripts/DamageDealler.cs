using UnityEngine;
public class DamageDealler : MonoBehaviour
{
    public float damage;
    private Animator anim;
    public LayerMask layerMask;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & layerMask) != 0)
        {
            if (collision.CompareTag("Damageable"))
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(damage);
                anim.SetTrigger("explod");
            }
            if (collision.CompareTag("Player"))
            {
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
        }
    }
    public void DestoyerPlasma()
    {
        Destroy(gameObject);
    }
    public void UpgradeDamage(float _damage)
    {
        damage += _damage;
    }
}

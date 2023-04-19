using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //Настройки жизни
    [SerializeField] private float maxHealth;
    private float currentHealth;
    private bool isAlive;
    private const int maxSlices = 15;
    [SerializeField] private GameObject soulCitizen;
    [SerializeField] private GameObject electedSoulHiding;
    //Аниматор
    [SerializeField] private Animator animDamaged;

    private void Awake()
    {
        animDamaged = GetComponent<Animator>();
        currentHealth = maxHealth;
        isAlive = true;
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        CheckIsAlive();
        animDamaged.SetTrigger("Hit");
    }
    private void CheckIsAlive()
    {
        isAlive = currentHealth > 0;
        if (isAlive == false)
        {
            Invoke("Destroyed", 1);
            animDamaged.SetTrigger("isDie");
        }
    }
    public void Destroyed()
    {
        Destroy(gameObject);
        GameObject currentelectedSoul = Instantiate(electedSoulHiding, transform.position, Quaternion.identity);
    }
    public void CreateSoul()
    {
        GameObject currentSoul = Instantiate(soulCitizen, transform.position, Quaternion.identity);
    }
}

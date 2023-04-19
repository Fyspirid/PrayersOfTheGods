using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //Настройки жизни
    [SerializeField] private float maxHealth;
    private float currentHealth;
    private bool isAlive;
    [SerializeField] private Image healthBarFill;
    private const int maxSlices = 15;
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
        UpdateHealthBar();
    }
    private void CheckIsAlive()
    {
        isAlive = currentHealth > 0;
        if (isAlive == false)
        {
            animDamaged.SetTrigger("isDie");
        }
    }
    private void UpdateHealthBar()
    {
        animDamaged.SetTrigger("isDamaged");
        int filledSlices = Mathf.RoundToInt(currentHealth / (maxHealth / maxSlices));
        float fillAmount = filledSlices / (float)maxSlices;
        healthBarFill.fillAmount = fillAmount;
    }
    public void Destroyed()
    {
        Destroy(gameObject);
    }
    public void IncreaseHealth(float amount)
    {
        maxHealth += amount;

        currentHealth = maxHealth;

        // Обновление полоски здоровья
        UpdateHealthBar();
    }
}

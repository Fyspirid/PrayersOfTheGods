using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeSummon : MonoBehaviour
{
    public GameManager gameManager;
    public int upgradeCost = 1;
    public int playerHealthUpgrade = 20;
    public int playerDamageUpgrade = 25;
    public PlayerHealth playerHealth;
    public DamageDealler plasmaDamage;
    [SerializeField] private GameObject shield;

    public void Upgrade1()
    {
        if (gameManager.GetScoreElected() >= upgradeCost)
        {
            gameManager.RemoveSoulElected(upgradeCost); 
            playerHealth.IncreaseHealth(playerHealthUpgrade);
        }
    }

    public void Upgrade2()
    {
        if (gameManager.GetScoreElected() >= upgradeCost)
        {
            gameManager.RemoveSoulElected(upgradeCost);
            plasmaDamage.UpgradeDamage(playerDamageUpgrade);
        }
    }

    public void Upgrade3()
    {
        if (gameManager.GetScoreElected() >= upgradeCost)
        {
            gameManager.RemoveSoulElected(upgradeCost);
            shield.SetActive(true);
        }
    }
}

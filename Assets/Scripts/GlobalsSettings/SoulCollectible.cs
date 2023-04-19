using TMPro;
using UnityEngine;

public class SoulCollectible : MonoBehaviour
{
    [Header("StandartSouls")]
    public int souls = 0;
    public TMP_Text soulText;

    [Header("ElectedSouls")]
    public int electedSouls = 0;
    public TMP_Text soulElectedText;

    private bool isClaim = false;
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;

        souls = gameManager.souls;
        electedSouls = gameManager.electedSouls;
        soulText.text = souls.ToString();
        soulElectedText.text = electedSouls.ToString();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Soul"))
        {
            souls++;
            soulText.text = souls.ToString();
            Destroy(collision.gameObject);
            gameManager.AddSouls(1);
            UpdateScoreText();
        }
        if (collision.CompareTag("SecretSoul"))
        {
            electedSouls++;
            soulElectedText.text = electedSouls.ToString();
            Destroy(collision.gameObject);
            gameManager.AddSoulsElected(1);
            UpdateScoreText();
        }
    }
    public void UpdateScoreText()
    {
        soulText.text = gameManager.GetScore().ToString();
        soulElectedText.text = gameManager.GetScoreElected().ToString();
    }
    public void CollectSoul()
    {
        souls++;
        PlayerPrefs.SetInt("Souls", souls);
    }
}

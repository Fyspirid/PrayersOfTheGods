using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //Lose
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TMP_Text collectibleSoulsLose;
    //Win
    [SerializeField] private GameObject gameWinScreen;
    [SerializeField] private TMP_Text collectibleSoulsWin;
    //Setiings
    [SerializeField] private GameObject settings;

    [SerializeField] private GameObject HPBar;
    [SerializeField] private GameObject talentTree;

    private SoulCollectible soulCollectible;

    private PlayerRespawn playerRespawn;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
        soulCollectible = FindObjectOfType<SoulCollectible>();
        playerRespawn = FindObjectOfType<PlayerRespawn>();
        GameManager gameManager = GameManager.Instance;

    }
    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void GameWin()
    {
        gameWinScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        gameOverScreen.SetActive(false);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = playerRespawn.currentCheckpoint.position;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1.0f;
        gameWinScreen.SetActive(false);
        HPBar.SetActive(false);
    }
    public void StartGame()
    {
        talentTree.SetActive(false);
        Time.timeScale = 1.0f;
        gameWinScreen.SetActive(false);
        HPBar.SetActive(true);
    }
    public void SettingMenu()
    {
        if (settings.activeSelf) 
            settings.SetActive(false);
        else
            settings.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
    private void Update()
    {
        SoulCounting();
        if (Time.timeScale == 1.0f)
            gameWinScreen.SetActive(false);
    }
    private void SoulCounting()
    {
        collectibleSoulsLose.text = collectibleSoulsWin.text;
        collectibleSoulsWin.text = (soulCollectible.souls.ToString() + "\n\n" + soulCollectible.electedSouls.ToString());
    }
    public void RestartScore()
    {
        GameManager.Instance.ResetScore();
    }
}

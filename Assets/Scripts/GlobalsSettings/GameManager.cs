using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject gameOverScreen;

    public int souls;
    public int electedSouls;

    [SerializeField] private TMP_Text souled;
    [SerializeField] private TMP_Text souledElect;

    [SerializeField] private Transform summon;
    [SerializeField] private Vector3 targetPostion;

    private void Awake()
    {
        //GameManager будет существовать только в одном экземпляре на сцену
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        // Загружаем количество очков, если оно было сохранено в прошлой сцене
        souls = PlayerPrefs.GetInt("Souls", souls);
        electedSouls = PlayerPrefs.GetInt("ElectedSouls", electedSouls);
    }
    public void AddSouls(int amount)
    {
        int lastSouls = PlayerPrefs.GetInt("Souls", 0);
        int soulsToAdd = souls - lastSouls;

        souls += soulsToAdd + amount;
    }
    public void AddSoulsElected(int amount)
    {
        electedSouls += amount;
    }
    public void RemoveSoul(int amount)
    {
        souls -= amount;
    }
    public void RemoveSoulElected(int amount)
    {
        electedSouls -= amount;
    }

    public void SaveScore()
    {
        // Сохраняем количество очков в PlayerPrefs
        PlayerPrefs.SetInt("Souls", souls);
        PlayerPrefs.SetInt("ElectedSouls", electedSouls);
        PlayerPrefs.Save();
    }

    public int GetScore()
    {
        return souls;
    }
    public int GetScoreElected()
    {
        return electedSouls;
    }

    public void LoadNextScene()
    {
        // Сохраняем количество очков перед переходом на следующую сцену
        SaveScore();

        // Загружаем следующую сцену
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
            Time.timeScale = 1f;
        }
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
        gameOverScreen.SetActive(false);
        summon.position = targetPostion;
    }
    public void ResetScore()
    {
        PlayerPrefs.DeleteAll();
        souls = 0;
        electedSouls = 0;
    }
    private void SoulCounting()
    {
        souled.text = souls.ToString();
        souledElect.text = electedSouls.ToString();
    }
    private void Update()
    {
        SoulCounting();
    }
}

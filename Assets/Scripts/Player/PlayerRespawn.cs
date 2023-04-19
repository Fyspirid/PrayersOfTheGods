using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private UIManager uiManager;
    public Transform currentCheckpoint;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }
    public void CheckRespawn()
    {
        uiManager.GameOver();
        Time.timeScale = 0.0f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathZone"))
            CheckRespawn();
        if (collision.CompareTag("WinGame"))
            uiManager.GameWin();
        if (collision.CompareTag("Checkpoint"))
        {
            currentCheckpoint = collision.transform;
        }
    }
    public void RespawnPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // получаем объект игрока
        player.transform.position = currentCheckpoint.position; // перемещаем игрока на точку респауна
    }
}

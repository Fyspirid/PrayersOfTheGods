using UnityEngine;
using UnityEngine.Playables;

public class CutSceneManager : MonoBehaviour
{
    [SerializeField] private PlayableDirector cutSceneFirst;
    [SerializeField] private PlayableDirector cutsceneEnd;
    [SerializeField] private Canvas canvasSceneEnd;
    private PlayerInput controll;
    [SerializeField] private GameObject boss;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip battleMusic;
    [SerializeField] private SpawnSilverGuards spawnSilverGuards;


    private void Awake()
    {
        controll = FindObjectOfType<PlayerInput>();
    }
    public void StartCutscene()
    {
        controll.enabled = false;
        canvasSceneEnd.gameObject.SetActive(true);
        cutsceneEnd.gameObject.SetActive(true);
        cutsceneEnd.Play();
    }
    public void EndCutScene()
    {
        controll.enabled = true;
        Destroy(boss);
        audioSource.clip = battleMusic;
        audioSource.Play();
        Destroy(GetComponent<BoxCollider2D>());
        spawnSilverGuards.SpawnObjects();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCutscene();
            Invoke("EndCutScene", 25f);
        }
    }
}

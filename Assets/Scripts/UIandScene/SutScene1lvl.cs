using UnityEngine;
using UnityEngine.Playables;

public class SutScene1lvl : MonoBehaviour
{
    [SerializeField] private PlayableDirector cutSceneFirst;
    [SerializeField] private PlayableDirector cutsceneEnd;
    [SerializeField] private Canvas canvasSceneEnd;
    private PlayerInput controll;

    private void Awake()
    {
        controll = FindObjectOfType<PlayerInput>();
        controll.enabled = false;
        Invoke("EndCutScene", 21f);
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCutscene();
            Invoke("EndCutScene", 9f);
        }
    }
}

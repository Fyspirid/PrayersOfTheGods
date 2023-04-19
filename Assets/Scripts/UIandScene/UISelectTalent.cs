using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISelectTalent : MonoBehaviour
{
    [SerializeField] private Image lightOfGod;
    private float timer;
    private Animator anim;

    [SerializeField] private TMP_Text addHP;
    private float duration = 1f;
    [SerializeField] private float startY;
    [SerializeField] private float endY;

    public GameManager gameManager;

    private bool isAnimating = false;
    private float startTime;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        lightOfGod.fillAmount = 0;
        lightOfGod.gameObject.SetActive(false);
        addHP.color = new Color(addHP.color.r, addHP.color.g, addHP.color.b, 0f);
    }
    public void OnButtonClicked()
    {
        if (!isAnimating)
        {
            startTime = Time.time;
            isAnimating = true;
        }
    }
    private void Update()
    {
        timer += Time.deltaTime;
        lightOfGod.fillAmount = timer;

        if (isAnimating)
        {
            float timeSinceStart = Time.time - startTime;
            float alpha = timeSinceStart / duration;

            // Устанавливаем значение альфа канала
            addHP.color = new Color(addHP.color.r, addHP.color.g, addHP.color.b, alpha);

            // Вычисляем новую позицию по оси Y
            float newY = Mathf.Lerp(startY, endY, alpha);

            // Устанавливаем новую позицию
            Vector3 newPosition = addHP.rectTransform.localPosition;
            newPosition.y = newY;
            addHP.rectTransform.localPosition = newPosition;

            if (alpha >= 1f)
            {
                isAnimating = false;
            }
        }
    }
    public void SelectTalent()
    {
        anim.SetTrigger("select");
    }
    public void FilledLight()
    {
        timer = 0;
        lightOfGod.gameObject.SetActive(true);
        Invoke("OnButtonClicked", 1f);
    }
}

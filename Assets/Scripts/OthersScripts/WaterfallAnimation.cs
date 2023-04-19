using System.Collections;
using UnityEngine;

public class WaterfallAnimation : MonoBehaviour
{
    [SerializeField] private GameObject[] waterfall;
    [SerializeField] private float switchInterval = 0.5f;
    private int currentIndex = 0;

    void Start()
    {
        // начинаем корутину, которая будет переключать спрайты
        StartCoroutine(SwitchObject());
    }

    IEnumerator SwitchObject()
    {
        while (true)
        {
            // отключаем все объекты
            foreach (GameObject obj in waterfall)
            {
                obj.SetActive(false);
            }

            // включаем следующий объект
            waterfall[currentIndex].SetActive(true);

            // инкрементируем индекс для следующего объекта
            currentIndex++;

            // если мы вышли за пределы массива, возвращаемся к началу
            if (currentIndex >= waterfall.Length)
            {
                currentIndex = 0;
            }

            // ждем заданный интервал времени
            yield return new WaitForSeconds(switchInterval);
        }
    }
}

using System.Collections;
using UnityEngine;

public class WaterfallAnimation : MonoBehaviour
{
    [SerializeField] private GameObject[] waterfall;
    [SerializeField] private float switchInterval = 0.5f;
    private int currentIndex = 0;

    void Start()
    {
        // �������� ��������, ������� ����� ����������� �������
        StartCoroutine(SwitchObject());
    }

    IEnumerator SwitchObject()
    {
        while (true)
        {
            // ��������� ��� �������
            foreach (GameObject obj in waterfall)
            {
                obj.SetActive(false);
            }

            // �������� ��������� ������
            waterfall[currentIndex].SetActive(true);

            // �������������� ������ ��� ���������� �������
            currentIndex++;

            // ���� �� ����� �� ������� �������, ������������ � ������
            if (currentIndex >= waterfall.Length)
            {
                currentIndex = 0;
            }

            // ���� �������� �������� �������
            yield return new WaitForSeconds(switchInterval);
        }
    }
}

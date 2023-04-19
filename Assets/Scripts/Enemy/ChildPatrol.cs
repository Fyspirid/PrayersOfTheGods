using UnityEngine;
public class ChildPatrol : MonoBehaviour
{
    //��� ������ ����� ����������� ���� ��������� ��������
    public delegate void OnChildDestroyed();
    public static event OnChildDestroyed ChildDestroyed;
    void OnDestroy()
    {
        if (ChildDestroyed != null)
            ChildDestroyed();
    }
}

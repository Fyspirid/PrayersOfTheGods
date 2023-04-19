using UnityEngine;
public class ChildPatrol : MonoBehaviour
{
    //При смерти юнита уничтожение всех связанных объектов
    public delegate void OnChildDestroyed();
    public static event OnChildDestroyed ChildDestroyed;
    void OnDestroy()
    {
        if (ChildDestroyed != null)
            ChildDestroyed();
    }
}

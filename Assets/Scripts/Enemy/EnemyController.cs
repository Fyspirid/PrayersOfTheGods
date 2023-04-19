using Unity.VisualScripting;
using UnityEngine;
public class EnemyController : MonoBehaviour
{
    //Логика движения юнита по области
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [SerializeField] private GameObject enemy;

    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;
    private void Awake()
    {
        initScale = enemy.transform.localScale;
        ChildPatrol.ChildDestroyed += DestroyParent;
    }
    private void Update()
    {
        if (movingLeft) 
        {
            if (enemy.transform.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
                DirectionChange();
        }
        else
        {
            if (enemy.transform.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
                DirectionChange();
        }
    }
    private void DirectionChange()
    {
        movingLeft = !movingLeft;
    }    
    private void MoveInDirection(int _direction)
    {
        enemy.transform.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);
        enemy.transform.position = new Vector2(enemy.transform.position.x + Time.deltaTime * _direction * speed, enemy.transform.position.y);
    }
    void DestroyParent()
    {
        Destroy(gameObject);
    }
}

using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Transform endPoint;
    [SerializeField] private float speed;

    public void RunMonster()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPoint.position, speed * Time.deltaTime);
        anim.SetTrigger("run");
    }
}

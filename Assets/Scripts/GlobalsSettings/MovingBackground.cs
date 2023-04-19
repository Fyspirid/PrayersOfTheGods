using UnityEngine;
using UnityEngine.UIElements;

public class MovingBackground : MonoBehaviour
{
    [SerializeField] private Transform[] trucks;
    private Vector3[] startPositions;
    [SerializeField] private Vector3 endPosition;
    [SerializeField] private float speed;
    void Start()
    {
        int numOfObjects = trucks.Length;
        startPositions = new Vector3[numOfObjects];
        for (int i = 0; i < numOfObjects; i++)
        {
            startPositions[i] = trucks[i].position;
        }
    }
    void Update()
    {
        int numOfObjects = trucks.Length;
        for (int i = 0; i < numOfObjects; i++)
        {
            trucks[i].position = Vector2.MoveTowards(trucks[i].position, endPosition, speed);
            if (trucks[i].position == endPosition)
            {
                trucks[i].position = startPositions[i];
            }
        }
    }
}

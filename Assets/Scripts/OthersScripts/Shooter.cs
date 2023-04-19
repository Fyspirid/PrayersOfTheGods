using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject plasma;
    [SerializeField] private float fireSpeed;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject effectorPrefab;
    private float currentScale;
    private Vector3 lastScale = new Vector3 (1, 1, 1);

    private void Awake()
    {
        currentScale = 1f;
    }
    public void Shoot(float direction)
    {
        GameObject currentPlasm = Instantiate(plasma, firePoint.position, Quaternion.identity);
        Rigidbody2D currentPlasmaVelocity = currentPlasm.GetComponent<Rigidbody2D>();

        if (direction >= 0)
        {
            currentPlasmaVelocity.velocity = new Vector2(fireSpeed * currentScale, currentPlasmaVelocity.velocity.y);
            Destroy(currentPlasm, 1f);
        }
        else if (direction <= 0)
        {
            currentPlasmaVelocity.velocity = new Vector2(fireSpeed * currentScale, currentPlasmaVelocity.velocity.y);
            Destroy(currentPlasm, 1f);
        }
        GameObject effector = Instantiate(effectorPrefab, plasma.transform.position, Quaternion.identity);
        Destroy(effector, 0.5f);
    }
    private void Update()
    {
        if (transform.localScale != lastScale)
        {
            currentScale *= -1f;
            lastScale = transform.localScale;
        }
    }
}

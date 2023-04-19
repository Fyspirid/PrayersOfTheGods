using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float speed;
    [SerializeField] private bool isGrounded = false;

    [Header("Settings")]
    [SerializeField] private Transform groundColliderTransform;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private float jumpOffset;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] private Animator animRun;
    private bool isRunning;

    private bool canMove = true; // ���������� ��� ������������, ��������� �� � ������ ������ ���������� �������
    private Rigidbody2D rb;

    bool isGhost = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animRun = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Vector3 overlapCirclePosition = groundColliderTransform.position;
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);
    }

    public void Move(float direction, bool isJumpButtonPressed)
    {
        if (!canMove) // ���� ���������� ������� ���������, �� ������ �� ������
        {
            return;
        }

        if (isJumpButtonPressed)
            Jump();

        if (Mathf.Abs(direction) > 0.01f)
        {
            animRun.SetBool("isRunning", true);
            HorizontalMovement(direction);
        }
        else
        {
            animRun.SetBool("isRunning", false);
        }
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void HorizontalMovement(float direction)
    {
        rb.velocity = new Vector2(curve.Evaluate(direction), rb.velocity.y);
        if (direction < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (direction > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void StopMovement()
    {
        canMove = false; // ��������� ���������� �������
        speed = 0;
        jumpForce = 0;
    }

    public void ResumeMovement()
    {
        canMove = true; // ��������� ���������� �������
        speed = 1.5f;
        jumpForce = 3f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            isGhost = !isGhost;
            if (isGhost)
            {
                // ��������� �������� ����� ���������� � ������� ���������
                Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Ground"), true);
                Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"), true);
            }
            else
            {
                // �������� �������� �������
                Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Ground"), false);
                Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"), false);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (isGhost && other.gameObject.CompareTag("Wall"))
        {
            // �������� ������ �����
            transform.position += transform.forward * 0.5f;
        }
        else if (isGhost && other.gameObject.CompareTag("Damageable"))
        {
            // �������� ������ ������
            Destroy(other.gameObject);
        }
    }
}

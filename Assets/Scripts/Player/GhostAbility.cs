using UnityEngine;

public class GhostAbility : MonoBehaviour
{
    bool isGhost = false;
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

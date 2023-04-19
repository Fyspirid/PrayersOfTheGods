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
                // отключаем коллизии между персонажем и другими объектами
                Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Ground"), true);
                Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"), true);
            }
            else
            {
                // включаем коллизии обратно
                Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Ground"), false);
                Physics.IgnoreLayerCollision(gameObject.layer, LayerMask.NameToLayer("Enemy"), false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (isGhost && other.gameObject.CompareTag("Wall"))
        {
            // проходим сквозь стены
            transform.position += transform.forward * 0.5f;
        }
        else if (isGhost && other.gameObject.CompareTag("Damageable"))
        {
            // проходим сквозь врагов
            Destroy(other.gameObject);
        }
    }
}

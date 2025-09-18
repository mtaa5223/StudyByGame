using UnityEngine;

public class Shield : MonoBehaviour
{
    public Transform player; // 플레이어 Transform 연결 (인스펙터에서 드래그 or 코드에서 찾기)

    void Update()
    {
        if (player != null)
        {
            transform.position = player.position; // 항상 플레이어 위치로 이동
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            CardManager.Instance.ShieldActive = false;
        }
    }
}

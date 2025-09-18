using UnityEngine;
using System.IO;
using System.Collections;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    // ===== 카드 효과 상태값 =====
    public bool ShieldActive = false;       // ShieldCard
    public bool BulletActive = false;       // GunCard
    public bool ScoreBoostActive = false;   // ScoreCard
    public bool GoggleActive = false;       // GoggleCard
    public bool DrillActive = false;        // DrillCard
    public bool ShoesActive = false;        // ShoesCard
    public bool CloverActive = false;       // CloverCard

    public int MaxHealthBonus = 0;

    // ===== 실제 게임 오브젝트 참조 =====
    public GameObject shieldObject;
    public GameObject drillObject;
    public GameObject bulletPrefab;
    void Update()
    {
        // Shield 예시
        if (shieldObject != null)
        {
            shieldObject.SetActive(ShieldActive);
        }

        if (BulletActive)
        {
            Instantiate(bulletPrefab, transform.position + Vector3.up * 1.5f, Quaternion.identity);
        }
        if (BulletActive)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position + Vector3.up * 1.5f, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.linearVelocity = Vector2.right * 10f; // 오른쪽(x+)으로 속도 10
        }
        if (GoggleActive)
        {
            Debug.Log("점수 증가량 상승 효과 발동 중!");
        }
        if (DrillActive)
        {
        StartCoroutine(DrillRoutine());
        }
        if (ShoesActive)
        {
            Debug.Log("가시류 데미지 감소 효과 발동 중!");
        }
        if (CloverActive)
        {
            Debug.Log("골드 획득량 증가 효과 발동 중!");
        }
        if (MaxHealthBonus > 0)
        {
            Debug.Log($"최대 체력 보너스: {MaxHealthBonus}");
        }
    }

  IEnumerator DrillRoutine()
    {
        while (DrillActive)
        {
            // 드릴 생성
            drillObject.SetActive(true);
            // 10초 대기
            yield return new WaitForSeconds(10f);
        }
    }
}

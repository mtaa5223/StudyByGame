using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Camera cam;

    void Start()
    {
        cam = GameObject.FindFirstObjectByType<Camera>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.GetComponent<PlayerHealth>().healthState == HealthState.NotTakingDamage)
        {
            if (CardManager.Instance.ShieldActive == true)
            {
                return;
            }
            other.GetComponent<PlayerHealth>().healthState = HealthState.TakingDamage;
            other.GetComponent<PlayerHealth>().TakeDamage(0.05f);
            StartCoroutine(BlinkPlayer(other.gameObject));
            StartCoroutine(HitStopAndShake());
        }
    }

    IEnumerator BlinkPlayer(GameObject player)
    {
        Renderer[] renderers = player.GetComponentsInChildren<Renderer>();

        float duration = 2f;
        float elapsed = 0f;

      while (elapsed < duration)
{
    foreach (Renderer r in renderers)
    {
        SpriteRenderer sr = r.GetComponent<SpriteRenderer>();
        sr.color = new Color32(255, 255, 255, 156); // 반투명
    }
    yield return new WaitForSeconds(0.2f);

    foreach (Renderer r in renderers)
    {
        SpriteRenderer sr = r.GetComponent<SpriteRenderer>();
        sr.color = new Color32(255, 255, 255, 255); // 다시 원래대로
    }
    yield return new WaitForSeconds(0.2f);

    elapsed += 0.4f;
}

        player.GetComponent<PlayerHealth>().healthState = HealthState.NotTakingDamage;
    }

    IEnumerator HitStopAndShake()
    {
        if (cam == null) yield break; // 카메라 없으면 그냥 종료

        Vector3 originalPos = cam.transform.localPosition;

        float shakeDuration = 0.2f;
        float shakeAmount = 0.1f;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            cam.transform.localPosition = originalPos + (Vector3)Random.insideUnitCircle * shakeAmount;
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        cam.transform.localPosition = originalPos; // 원위치
    }
}

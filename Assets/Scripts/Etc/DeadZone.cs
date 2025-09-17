using UnityEngine;

public class DeadZone : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            // 여기에 게임 오버 처리 로직 추가
            Time.timeScale = 0; // 게임 일시정지

        }
    }
}

using System.Collections.Generic;
using UnityEngine;

// 왼쪽 끝으로 이동한 배경을 오른쪽 끝으로 재배치하는 스크립트
public class BackgroundLoad : MonoBehaviour {
   [SerializeField] private float width; // 배경의 가로 길이
   private int loopNumder = 0;
   public Sprite[] backGroundImag;
   private SpriteRenderer _spriteRenderer;
   
    private void Awake() {
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        width = backgroundCollider.size.x;
    }

    private void Update() {
        // 현재 위치가 원점에서 왼쪽으로 width 이상 이동했을때 위치를 리셋
        if (transform.position.x <= -width)
        {
            loopNumder++;
            Reposition();
        }
    }

    // 위치를 리셋 및 배경 변경 하는 메서드
    private void Reposition() {
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2) transform.position + offset;
        if (loopNumder % 15 == 0)
        {
            _spriteRenderer.sprite = backGroundImag[1];
            // platform Manager에서 나오는 몬스터 다르게 추가
            
        }
        // GetComponent<PlatformManager>().PlatformActiveF();
        // GetComponent<PlatformManager>().ActivePlatform();
    }
}
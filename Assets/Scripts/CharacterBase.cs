using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    [System.Serializable] 
    public class CharacterData
    {
        public string name;      // 캐릭터 이름
        public int maxHp;        // 최대 체력
        public int attack;       // 공격력
        public int defense;      // 방어력
        public float moveSpeed;  // 이동 속도
        public float jumpForce;  // 점프 힘
        public int maxJumps;     // 최대 점프 횟수
    }

    [Header("Character Info")]
    public CharacterData characterData; 
}

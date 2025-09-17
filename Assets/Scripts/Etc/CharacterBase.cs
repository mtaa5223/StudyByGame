using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    [System.Serializable]
    public class CharacterData
    {
        public string name;      // 캐릭터 이름
        public int maxHp;        // 최대 체력
        public float moveSpeed;  // 이동 속도
        public int coin;        // 코인 수
    }

    [Header("Character Info")]
    public CharacterData characterData; 
}

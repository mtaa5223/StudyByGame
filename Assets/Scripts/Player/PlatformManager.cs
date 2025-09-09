using UnityEngine;

public class PlatformManager : MonoBehaviour
{

    [SerializeField] private GameObject[] Platforms;

    private int PlatformIndex;
    void Start()
    {
        ActivePlatform();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //플랫폼 랜덤으로 돌리는 함수
   public void ActivePlatform()
    {
        PlatformIndex = Random.Range(0, Platforms.Length);
        PlatformActiveT(PlatformIndex);
    }
    
    //플랫폼 활성화
    private void PlatformActiveT(int index)
    {
        Platforms[index].SetActive(true);
    }
    
    //플랫폼 비활성화 
    public void PlatformActiveF()
    {
        for (int i = 0; i < Platforms.Length; i++)
        {
            if (Platforms[i].activeSelf)
            {
                gameObject.SetActive(false);
            }
        }
    }
    
}

using UnityEngine;
using System.IO;
using System;

public class CardView : Singleton<CardView>
{
    
public GameObject cardPrefab; // 프리팹 원본
public Transform cardParent; // 부모 UI
    // 전역 wrapper 선언
    public CardDataWrapper wrapper;
    void Start()
    {
        LoadJson();
        RandomCard();
    }


public void RandomCard()
{
    cardParent.DetachChildren(); // 기존 카드 제거
    for (int i = 0; i < 3; i++) // 슬롯 3개만 뽑기
        {
            int randomIndex = UnityEngine.Random.Range(0, wrapper.CardData.Length);
            CardData selectedCard = wrapper.CardData[randomIndex];
            GameObject cardObj = Instantiate(cardPrefab, cardParent);
            CardViewItem item = cardObj.GetComponent<CardViewItem>();
            item.SetCardData(selectedCard.id, selectedCard.title, selectedCard.description);
        }
}

     void LoadJson()
    {
        // Data 폴더 안 JSON 경로 지정
        string path = Path.Combine(Application.dataPath, "Data/CardData.json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            wrapper = JsonUtility.FromJson<CardDataWrapper>(json);
        }
        else
        {
            Debug.LogError("CardData.json 파일을 찾을 수 없습니다: " + path);
        }
    }
}

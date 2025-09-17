using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class CardViewItem : MonoBehaviour
{
    public int id;
    public string title;
    public string description;
    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public Button button;
    public void SetCardData(int Id, string title, string description)
    {
        id = Id;
        this.title = title;
        this.description = description;
        titleText.text = title;
        descriptionText.text = description;
    }
    public void OnclickCard()
    {
        CardFactory cardFactory = new CardFactory();
        ICard card = cardFactory.CreateCard(id);
        if (card != null)
        {
        card.UseCard(); // 실제 효과 실행
        }
        Debug.Log($"Card Clicked: id={id}, title={title}, description={description}");
        Time.timeScale = 1;
        CoinManager.Instance.cardCanvas.SetActive(false);
    }                                   
}

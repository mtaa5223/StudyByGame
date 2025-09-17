using UnityEngine;
using UnityEngine.UI;

public class CoinManager : Singleton<CoinManager>
{
    public int level = 0;
    public Slider coinFill;
    public GameObject cardCanvas;

    public void GetCoin(float coinValue)
    {
        coinFill.value += coinValue;

        if (coinFill.value >= 1)
        {
            coinFill.value = 0;
            level++;
            cardCanvas.SetActive(true);
            Time.timeScale = 0;
           CardView.Instance.RandomCard();
        }
    }
}

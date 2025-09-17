using UnityEngine;

public class Coin : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Coin"))
        {
            GameManager.Instance.coinValue++;

            if (CoinManager.Instance.level == 0)
            {
                CoinManager.Instance.GetCoin(0.2f);
            }
            else if (CoinManager.Instance.level == 1)
            {
                CoinManager.Instance.GetCoin(0.1f);
            }
            else if (CoinManager.Instance.level == 2)
            {
                CoinManager.Instance.GetCoin(0.07f);
            }
            else if (CoinManager.Instance.level == 3)
            {
                CoinManager.Instance.GetCoin(0.05f);
            }
            else if (CoinManager.Instance.level == 4)
            {
                CoinManager.Instance.GetCoin(0.03f);
            }
            else if (CoinManager.Instance.level == 5)
            {
                CoinManager.Instance.GetCoin(0.01f);
            }
            else if (CoinManager.Instance.level == 6)
            {
                CoinManager.Instance.GetCoin(0.009f);
            }
            else if (CoinManager.Instance.level == 7)
            {
                CoinManager.Instance.GetCoin(0.008f);
            }
            else if (CoinManager.Instance.level == 8)
            {
                CoinManager.Instance.GetCoin(0.007f);
            }
            else if (CoinManager.Instance.level == 9)
            {
                CoinManager.Instance.GetCoin(0.006f);
            }
            else if (CoinManager.Instance.level == 10)
            {
                CoinManager.Instance.GetCoin(0.005f);
            }

            Destroy(gameObject);
        }
    }
}

using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    public int coinValue = 0;
    public TextMeshProUGUI coinText;

    void Update()
    {
        coinText.text = coinValue.ToString();
    }
}

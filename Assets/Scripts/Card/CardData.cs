using System.IO;
using UnityEngine;

[System.Serializable]
public class CardData
{
    public int id;
    public string title;
    public string description;
}

[System.Serializable]
public class CardDataWrapper
{
    public CardData[] CardData;
}



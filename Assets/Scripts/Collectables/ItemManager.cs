using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;
    public TextMeshProUGUI textoCollected;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.Value = 0;
    }

    public void AddCoins(int qtd = 1)
    {
        coins.Value += qtd;
        //textoCollected.text = string.Format("x {0:D3}", coins.Value);
    }
}

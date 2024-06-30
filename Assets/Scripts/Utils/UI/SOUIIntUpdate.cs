using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUIIntUpdate : MonoBehaviour
{
    public SOInt intColetados;
    public TextMeshProUGUI uiTextoValor;

    private void Start()
    {
        uiTextoValor.text = string.Format("x {0:D3}", intColetados.Value);
    }

    private void Update()
    {
        uiTextoValor.text = string.Format("x {0:D3}", intColetados.Value);
    }
}

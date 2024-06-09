using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuButtonsManager : MonoBehaviour
{
    public List<GameObject> lstButtons;

    [Header("Animation")]
    public float Duration = .2f;
    public float Delay = .05f;
    public Ease customEase = Ease.OutBack;

    public void OnEnable()
    {
        HideAllButtons();
        ShowButtons();
    }

    private void HideAllButtons()
    {
        foreach (var b in lstButtons)
        {
            b.transform.localScale = Vector3.zero;
            b.SetActive(false);
        }
    }

    private void ShowButtons()
    {
        for (int i = 0; i < lstButtons.Count; i++)
        {
            var b = lstButtons[i];
            b.SetActive(true);
            b.transform.DOScale(1, Duration).SetDelay(i * Delay).SetEase(customEase);
        }
    }
}

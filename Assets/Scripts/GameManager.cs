using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{
    [Header("Player")]
    public GameObject JogadorPrefab;

    [Header("Enemies")]
    public List<GameObject> lstEnemies;

    [Header("References")]
    public Transform StarPoint;

    [Header("Animation")]
    public float Duration = .2f;
    public float Delay = .05f;
    public Ease customEase = Ease.OutBack;

    private GameObject _currentJogador;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        SpawnJogador();
    }

    private void SpawnJogador()
    {
        _currentJogador = Instantiate(JogadorPrefab);
        _currentJogador.transform.position = StarPoint.transform.position;
        _currentJogador.transform.DOScale(0, Duration).SetEase(customEase).From();
    }
}

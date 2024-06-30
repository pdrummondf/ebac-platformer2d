using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
    [Header("Config Velocidade")]
    public float velocidade = 5;
    public float velocidadeCorrida = 10;
    public float forcaPulo = 2;
    public Vector2 atrito = new Vector2(.1f, 0);
    public float escalaCorridaX = 1.75f;
    public float escalaCorridaY = .75f;
    public Ease cstmEaseCorrida = Ease.OutBack;

    [Header("config Animation")]
    public float escalaPuloY = 1.5f;
    public float escalaPuloX = .5f;
    public float animationDur = .3f;
    public Ease cstmEase = Ease.OutBack;

    [Header("Animation Player")]
    public string triggerRun = "Run";
    public string triggerDeath = "Death";
}

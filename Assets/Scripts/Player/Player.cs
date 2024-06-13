using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D rbJogador;

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

    private bool _pouso = false;


    public void Update()
    {
        HandlePulo();
        HandleMovimentos();
    }

    private void HandleMovimentos()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rbJogador.velocity = new Vector2(Input.GetKey(KeyCode.LeftControl) ? -velocidadeCorrida : -velocidade, rbJogador.velocity.y);
            HandleEscalaCorrida();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rbJogador.velocity = new Vector2(Input.GetKey(KeyCode.LeftControl) ? velocidadeCorrida : velocidade, rbJogador.velocity.y);
            HandleEscalaCorrida();
        }

        if (rbJogador.velocity.x > 0)
        {
            rbJogador.velocity -= atrito;
        }
        else if (rbJogador.velocity.x < 0)
        {
            rbJogador.velocity += atrito;
        }
    }

    private void HandlePulo()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rbJogador.velocity = Vector2.up * forcaPulo;
            rbJogador.transform.localScale = Vector2.one;

            DOTween.Kill(rbJogador.transform);

            HandleEscalaPulo();

            _pouso = true;
        }
    }

    private void HandleEscalaPulo()
    {
        rbJogador.transform.DOScaleY(escalaPuloY, animationDur).SetLoops(2, LoopType.Yoyo).SetEase(cstmEase);
        rbJogador.transform.DOScaleX(escalaPuloX, animationDur).SetLoops(2, LoopType.Yoyo).SetEase(cstmEase);
    }

    private void HandleEscalaCorrida()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            rbJogador.transform.DOScaleX(escalaCorridaX, animationDur).SetLoops(2, LoopType.Yoyo).SetEase(cstmEaseCorrida);
            rbJogador.transform.DOScaleY(escalaCorridaY, animationDur).SetLoops(2, LoopType.Yoyo).SetEase(cstmEaseCorrida);
        }
        else
        {
            rbJogador.transform.localScale = Vector2.one;
            DOTween.Kill(rbJogador.transform);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Square"))
        {
            Debug.Log(collision.gameObject.name);

            if (_pouso)
            {
                _pouso = false;
                rbJogador.transform.localScale = Vector2.one;

                DOTween.Kill(rbJogador.transform);
                HandlePouso();
            }
        }
    }

    private void HandlePouso()
    {
        rbJogador.transform.DOScaleY(escalaPuloX, animationDur).SetLoops(2, LoopType.Yoyo).SetEase(cstmEase);
        rbJogador.transform.DOScaleX(escalaPuloY, animationDur).SetLoops(2, LoopType.Yoyo).SetEase(cstmEase);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D rbJogador;

    [Header("Setup")]
    public SOPlayerSetup soPlayerSetup;

    public Animator animatorPlayer;

    private bool _pouso = false;

    public HealthBase healthBase;

    [Header("Jump Setup")]
    public Collider2D collider2d;
    public float distToGround;
    public float spaceToGroud = .1f;
    public ParticleSystem puloVFX;

    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.onKill += OnPlayerKill;
        }

        if (collider2d != null)
        {
            distToGround = collider2d.bounds.extents.y;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position,-Vector2.up, distToGround + spaceToGroud);
    }

    private void OnPlayerKill()
    {
        healthBase.onKill -= OnPlayerKill;
        animatorPlayer.SetTrigger(soPlayerSetup.triggerDeath);
    }

    public void Update()
    {
        HandlePulo();
        HandleMovimentos();
    }

    private void HandleMovimentos()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rbJogador.velocity = new Vector2(Input.GetKey(KeyCode.LeftControl) ? -soPlayerSetup.velocidadeCorrida : -soPlayerSetup.velocidade, rbJogador.velocity.y);
            if (rbJogador.transform.localScale.x != -1)
            {
                rbJogador.transform.DOScaleX(-1, .1f);
            }
            animatorPlayer.SetBool(soPlayerSetup.triggerRun, true);
            //HandleEscalaCorrida();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rbJogador.velocity = new Vector2(Input.GetKey(KeyCode.LeftControl) ? soPlayerSetup.velocidadeCorrida : soPlayerSetup.velocidade, rbJogador.velocity.y);
            if (rbJogador.transform.localScale.x != 1)
            {
                rbJogador.transform.DOScaleX(1, .1f);
            }
            animatorPlayer.SetBool(soPlayerSetup.triggerRun, true);
            //HandleEscalaCorrida();
        }
        else
        {
            animatorPlayer.SetBool(soPlayerSetup.triggerRun, false);
        }

        if (rbJogador.velocity.x > 0)
        {
            rbJogador.velocity -= soPlayerSetup.atrito;
        }
        else if (rbJogador.velocity.x < 0)
        {
            rbJogador.velocity += soPlayerSetup.atrito;
        }
    }

    private void HandlePulo()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rbJogador.velocity = Vector2.up * soPlayerSetup.forcaPulo;
            if (rbJogador.transform.localScale.x != -1)
            {
                rbJogador.transform.DOScaleX(1, .1f);
            }
            if (rbJogador.transform.localScale.x != 1)
            {
                rbJogador.transform.DOScaleX(-1, .1f);
            }

            PlayPuloVFX();

            //DOTween.Kill(rbJogador.transform);

            //HandleEscalaPulo();

            //_pouso = true;
        }
    }

    private void PlayPuloVFX()
    {
        if (puloVFX != null)
        {
            puloVFX.Play();
        }
    }

    private void HandleEscalaPulo()
    {
        rbJogador.transform.DOScaleY(soPlayerSetup.escalaPuloY, soPlayerSetup.animationDur).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.cstmEase);
        rbJogador.transform.DOScaleX(soPlayerSetup.escalaPuloX, soPlayerSetup.animationDur).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.cstmEase);
    }

    private void HandleEscalaCorrida()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            rbJogador.transform.DOScaleX(soPlayerSetup.escalaCorridaX, soPlayerSetup.animationDur).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.cstmEaseCorrida);
            rbJogador.transform.DOScaleY(soPlayerSetup.escalaCorridaY, soPlayerSetup.animationDur).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.cstmEaseCorrida);
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
        rbJogador.transform.DOScaleY(soPlayerSetup.escalaPuloX, soPlayerSetup.animationDur).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.cstmEase);
        rbJogador.transform.DOScaleX(soPlayerSetup.escalaPuloY, soPlayerSetup.animationDur).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.cstmEase);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}

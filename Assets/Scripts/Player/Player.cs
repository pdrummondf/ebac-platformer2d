using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rbJogador;
    public float velocidade = 5;
    public float forcaPulo = 2;
    public Vector2 atrito = new Vector2(.1f, 0);


    public void Update()
    {
        HandlePulo();
        HandleMovimentos();
    }

    private void HandleMovimentos()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rbJogador.velocity = new Vector2(-velocidade, rbJogador.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rbJogador.velocity = new Vector2(velocidade, rbJogador.velocity.y);
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
        }
    }
}

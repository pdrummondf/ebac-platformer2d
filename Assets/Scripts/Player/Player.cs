using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rbJogador;
    public float velocidade = 15f;


    public void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rbJogador.velocity = new Vector2(-velocidade, rbJogador.velocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rbJogador.velocity = new Vector2(velocidade, rbJogador.velocity.y);            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 1;

    public Animator animatorAttack;
    public string gatilhoAtacar = "Attack";

    public HealthBase healthBase;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<HealthBase>();

        if (health != null)
        {
            health.Damage(damage);
            PlayAttackAnimation();
        }
    }

    private void PlayAttackAnimation()
    {
        animatorAttack.SetTrigger(gatilhoAtacar);
    }

    public void Damage(int qtd = 1)
    {
        healthBase.Damage(qtd);
    }
}

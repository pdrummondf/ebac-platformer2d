using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 1;

    public Animator animatorAttack;
    public string gatilhoAtacar = "Attack";
    public string gatilhoMorrer = "Death";

    public HealthBase healthBase;

    public float tempoParaDestruir = 1f;

    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.onKill += OnEnemyKill;
        }
    }

    private void OnEnemyKill()
    {
        healthBase.onKill -= OnEnemyKill;
        PlayDeathAnimation();
        Destroy(gameObject, tempoParaDestruir);
    }

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

    private void PlayDeathAnimation()
    {
        animatorAttack.SetTrigger(gatilhoMorrer);
    }

    public void Damage(int qtd = 1)
    {
        healthBase.Damage(qtd);
    }
}

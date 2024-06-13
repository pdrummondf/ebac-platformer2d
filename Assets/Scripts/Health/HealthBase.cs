using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HealthBase : MonoBehaviour
{
    public int startLife = 10;
    public bool destroyOnKill = false;
    public float delayOnKill = 0f;

    private int _currentLife;
    private bool isDead = false;


    public void Init()
    {
        isDead = false;
        _currentLife = startLife;
    }
    private void Awake()
    {
        Init();
    }

    public void Damage(int damage)
    {
        if (isDead) return;

        _currentLife -= damage;

        if (_currentLife <= 0)
        {
            Kill();
        }
    }

    public void Kill()
    {
        isDead = false;

        if (destroyOnKill)
        {
            var rbBody = gameObject.GetComponent<Rigidbody2D>();

            if (rbBody != null)
            {
                //Debug.Log(rbBody.gameObject.name);
                rbBody.transform.DOScaleY(.1f, .3f).SetEase(Ease.OutBack);
            }

            Destroy(gameObject,delayOnKill);
        }
    }
}

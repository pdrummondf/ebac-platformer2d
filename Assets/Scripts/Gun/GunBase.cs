using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase projectileBase;

    public Transform positionToShoot;
    public float tempoEntreShoot;
    private Coroutine _currentCorrotina;

    public Transform playerReference;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _currentCorrotina = StartCoroutine(StartShoot());
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            if (_currentCorrotina != null) StopCoroutine(_currentCorrotina);
        }
    }

    IEnumerator StartShoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(tempoEntreShoot);
        }
    }

    public void Shoot()
    {
        var projectile = Instantiate(projectileBase);
        projectile.transform.position = positionToShoot.position;
        projectile.side = playerReference.transform.localScale.x;
    }
}

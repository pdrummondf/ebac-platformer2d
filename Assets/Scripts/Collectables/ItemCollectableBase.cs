using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public string PlayerTag = "Player";
    public new ParticleSystem particleSystem;
    public float tempoEsconder = 3f;
    public GameObject graphicItem;


    private void Awake()
    {
        //Debug.Log("Entrou no awake.");
        //if (particleSystem != null) particleSystem.transform.SetParent(null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(PlayerTag))
        {
            Collect();
        }
    }
    protected virtual void Collect()
    {
        Debug.Log("Coletou a moeda!");
        if (graphicItem != null)
        {
            graphicItem.SetActive(false);
        }
        Invoke(nameof(HideObject), tempoEsconder);
        OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
    }
}

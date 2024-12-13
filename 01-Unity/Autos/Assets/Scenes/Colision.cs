using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private bool hasPackage;
    [SerializeField] private float destroyDelay = 0.5f;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entrando a trigger");
        
        if (other.tag == "Paquete" && !hasPackage)
        {
            Debug.Log("Paquete recogido");
            hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
        }
        
        if (other.tag == "Cliente" && hasPackage)
        {
            Debug.Log("Paquete entregado");
            hasPackage = false;
            spriteRenderer.color = Color.white;
        }
    }
}

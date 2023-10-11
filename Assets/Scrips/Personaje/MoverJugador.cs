
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverJugador : MonoBehaviour
{

    [SerializeField]
    PerfilJugador perfilJugador;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private Animator miAnimator;
    private SpriteRenderer miSprite;
    private BoxCollider2D miCollider2D;

    private int saltarMask;

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        miSprite = GetComponent<SpriteRenderer>();
        miCollider2D = GetComponent<BoxCollider2D>();
        saltarMask = LayerMask.GetMask("Pisos", "Plataformas");
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    private void Update()
    {
        perfilJugador.MoverHorizontal = Input.GetAxis("Horizontal");
        perfilJugador.Direccion = new Vector2(perfilJugador.MoverHorizontal, 0f);

        int velocidadX = (int)miRigidbody2D.velocity.x;
        miSprite.flipX = velocidadX < 0;
        miAnimator.SetInteger("Velocidad", velocidadX);

        miAnimator.SetBool("EnAire", !EnContactoConPlataforma()); // miRigidbody2D.velocity.y != 0f

    }

    private void FixedUpdate()
    {
        miRigidbody2D.AddForce(perfilJugador.Direccion * perfilJugador.Velocidad);
    }
    
    private bool EnContactoConPlataforma()
    {
        return miCollider2D.IsTouchingLayers(saltarMask);
    }
    
}
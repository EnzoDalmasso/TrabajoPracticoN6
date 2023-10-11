using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Jugador : MonoBehaviour
{
    [SerializeField]
    PerfilJugador perfilJugador;

    private ObjectCollector collector;

    [SerializeField]
    private UnityEvent<string> OnTextChanged;

    //-------------- Eventos del jugador ----------- //
    [SerializeField]
    private UnityEvent<int> OnlivesChanged;

    private void Start()
    {
        OnlivesChanged.Invoke(perfilJugador.Vida);
        collector = GetComponent<ObjectCollector>();
        OnTextChanged.Invoke(perfilJugador.Vida.ToString());
    }

    public void ModificarVida(int puntos)
    {
        perfilJugador.Vida += puntos;
        OnTextChanged.Invoke(perfilJugador.Vida.ToString());
        Debug.Log(EstasVivo());
    }


    private bool EstasVivo()
    {
        return perfilJugador.Vida > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Meta") && collector.CollectedCount<3) { return; }

        Debug.Log("GANASTE");
    }
}
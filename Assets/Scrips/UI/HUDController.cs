using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;

public class HUDController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI miTexto;
    [SerializeField] GameObject iconoVida;
    [SerializeField] GameObject contenedorInconosVida;

    public void ActualizarTextosHUD(string nuevoTxt)
    {
        Debug.Log("SE LLAMA" + nuevoTxt);
        miTexto.text= nuevoTxt;
    }

    public void ActualizarVidasHUD(int vidas)
    {
        Debug.Log("SUMANDO VIDAS");
        if(EstaVacioContenedor())
        {
            CargarContenedor(vidas);
            return;
        }

        if (CantidadIconosVidas()<vidas)
        {
            EliminarUltimoIcono();
        }
        else 
        {
            CrearIcono();
        }
    }

    private bool EstaVacioContenedor()
    {
        //Si un padre no tiene hijos utilizamos childCount
        return contenedorInconosVida.transform.childCount == 0;

    }
    private int CantidadIconosVidas()
    {
        return contenedorInconosVida.transform.childCount;
    }
    
    private void EliminarUltimoIcono()
    {
        Transform contenedor = contenedorInconosVida.transform;
        GameObject.Destroy(contenedor.GetChild(contenedor.childCount-1).gameObject);
    }

    private void CargarContenedor(int cantidadIconos)
    {

        for (int i = 0; i < cantidadIconos; i++)
        {
            CrearIcono();
        }
    }

    private void CrearIcono()
    {
        Instantiate(iconoVida,contenedorInconosVida.transform);
    }
}
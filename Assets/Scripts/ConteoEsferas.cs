using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConteoEsferas : MonoBehaviour
{
    public TextMeshProUGUI cubosText; // TextMeshPro para el conteo de cubos
    public TextMeshProUGUI esferasText; // TextMeshPro para el conteo de esferas

    private int cubosEliminados = 0;
    private int esferasEliminadas = 0;

    // Llamado cuando un cubo es eliminado
    public void CuboEliminado()
    {
        cubosEliminados++;
        ActualizarConteo();
    }

    // Llamado cuando una esfera es eliminada
    public void EsferaEliminada()
    {
        esferasEliminadas++;
        ActualizarConteo();
    }

    // Actualiza el texto del conteo
    private void ActualizarConteo()
    {
        cubosText.text = "Cubos Eliminados: " + cubosEliminados;
        esferasText.text = "Esferas Eliminadas: " + esferasEliminadas;
    }
}


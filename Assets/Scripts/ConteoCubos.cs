using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConteoCubos : MonoBehaviour
{
    public TextMeshProUGUI conteoText; // El objeto TextMeshPro donde mostrar el conteo

    private int cubosEliminados = 0;

    // Llamado cuando un cubo es eliminado
    public void CuboEliminado()
    {
        cubosEliminados++;
        ActualizarConteo();
    }

    // Actualiza el texto del conteo
    private void ActualizarConteo()
    {
        conteoText.text = "Cubos Eliminados: " + cubosEliminados;
    }
}


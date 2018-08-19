using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PruebasCanvas : MonoBehaviour {

    public Image Puntas;
    public Image Triangulo;
    public TMP_Dropdown DropdownCrosshair;

    public void Cambio()
    {
        if(DropdownCrosshair.value == 0)
        {
            Puntas.color = Color.red;
            Triangulo.color = Color.red;
        }

        if(DropdownCrosshair.value == 1)
        {
            Puntas.color = Color.cyan;
            Triangulo.color = Color.cyan;
        }

        if(DropdownCrosshair.value == 2)
        {
            Puntas.color = Color.white;
            Triangulo.color = Color.white;
        }
    }
}

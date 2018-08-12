using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {

    public GameObject SubPanelSonido;
    public GameObject SubPanelGraficos;
    public GameObject SubPanelCrosshair;
    public TMP_Dropdown DropdownGraficos;

    //Pone TRUE el SubPanel de opciones de sonido
    public void OnSubPanelSonido()
    {
        SubPanelSonido.SetActive(true);
        SubPanelGraficos.SetActive(false);
        SubPanelCrosshair.SetActive(false);
    }

    //Pone TRUE el SubPanel de opciones graficas
    public void OnSubPanelGraficos()
    {
        SubPanelGraficos.SetActive(true);
        SubPanelSonido.SetActive(false);
        SubPanelCrosshair.SetActive(false);
    }

    //Pone TRUE el SubPanel de opciones del Crosshair
    public void OnSubPanelCrosshair()
    {
        SubPanelCrosshair.SetActive(true);
        SubPanelSonido.SetActive(false);
        SubPanelGraficos.SetActive(false);
    }

    //Cambia las opciones graficas del juego
    public void CambiandoGraficos()
    {
        if (DropdownGraficos.value == 0)
        {
            QualitySettings.SetQualityLevel(0);
        }
        if (DropdownGraficos.value == 1)
        {
            QualitySettings.SetQualityLevel(1);
        }
        if (DropdownGraficos.value == 2)
        {
            QualitySettings.SetQualityLevel(2);
        }
        if (DropdownGraficos.value == 3)
        {
            QualitySettings.SetQualityLevel(3);
        }
        if (DropdownGraficos.value == 4)
        {
            QualitySettings.SetQualityLevel(4);
        }
        if (DropdownGraficos.value == 5)
        {
            QualitySettings.SetQualityLevel(5);
        }

    }

    //Comprobador de nivel grafico
    public void ComprobadorGrafico()
    {
        Debug.Log("El nivel grafico se encuentra en: " + QualitySettings.GetQualityLevel());
        DropdownGraficos.value = QualitySettings.GetQualityLevel();
    }

    private void Update()
    {
        ComprobadorGrafico();
    }
}

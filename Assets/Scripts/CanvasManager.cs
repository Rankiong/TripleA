﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class CanvasManager : MonoBehaviour {

    public AudioMixer Master;
    public AudioMixerGroup Music;
    public AudioMixerGroup SFX;

    public GameObject PanelJugar;
    public GameObject PanelOpciones;
    public GameObject PanelControles;
    public GameObject PanelCreditos;
    public GameObject PanelSalir;
    public GameObject SubPanelSonido;
    public GameObject SubPanelGraficos;
    public GameObject SubPanelCrosshair;
    public TMP_Dropdown DropdownGraficos;
    public TMP_Dropdown DropdownResoluciones;
    public TMP_Dropdown DropdownFullscreen;

    Resolution[] resoluciones;

    //Configurador de TRUE y FALSE para los subpaneles
    public void OnSubPanelSonido()
    {
        SubPanelSonido.SetActive(true);
        SubPanelGraficos.SetActive(false);
        SubPanelCrosshair.SetActive(false);
    }
    public void OnSubPanelGraficos()
    {
        SubPanelGraficos.SetActive(true);
        SubPanelSonido.SetActive(false);
        SubPanelCrosshair.SetActive(false);
    }
    public void OnSubPanelCrosshair()
    {
        SubPanelCrosshair.SetActive(true);
        SubPanelSonido.SetActive(false);
        SubPanelGraficos.SetActive(false);
    }
    
    //Configurador de TRUE y FALSE para los paneles
    public void OnPanelJugar()
    {
        PanelOpciones.SetActive(false);
        PanelControles.SetActive(false);
        PanelCreditos.SetActive(false);
        PanelSalir.SetActive(false);

        if(PanelJugar.activeSelf == false)
        {
            PanelJugar.SetActive(true);
        }
        else
        {
            PanelJugar.SetActive(false);
        }
    }
    public void OnPanelOpciones()
    {
        if (PanelOpciones.activeSelf == false)
        {
            PanelOpciones.SetActive(true);
        }
        else
        {
            PanelOpciones.SetActive(false);
        }

        PanelJugar.SetActive(false);
        PanelControles.SetActive(false);
        PanelCreditos.SetActive(false);
        PanelSalir.SetActive(false);
    }
    public void OnPanelControles()
    {
        if (PanelControles.activeSelf == false)
        {
            PanelControles.SetActive(true);
        }
        else
        {
            PanelControles.SetActive(false);
        }

        PanelJugar.SetActive(false);
        PanelOpciones.SetActive(false);
        PanelCreditos.SetActive(false);
        PanelSalir.SetActive(false);
    }
    public void OnPanelCreditos()
    {
        if (PanelCreditos.activeSelf == false)
        {
            PanelCreditos.SetActive(true);
        }
        else
        {
            PanelCreditos.SetActive(false);
        }

        PanelJugar.SetActive(false);
        PanelOpciones.SetActive(false);
        PanelControles.SetActive(false);
        PanelSalir.SetActive(false);
    }
    public void OnPanelSalir()
    {
        if (PanelSalir.activeSelf == false)
        {
            PanelSalir.SetActive(true);
        }
        else
        {
            PanelSalir.SetActive(false);
        }

        PanelJugar.SetActive(false);
        PanelOpciones.SetActive(false);
        PanelControles.SetActive(false);
        PanelCreditos.SetActive(false);
    }

    //Funciones de configuracion de las opciones del juego
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
    public void CambiandoResoluciones()
    {
        resoluciones = Screen.resolutions;

        DropdownResoluciones.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resoluciones.Length; i++)
        {
            string option = resoluciones[i].width + " x " + resoluciones[i].height;
            options.Add(option);

            if (resoluciones[i].width == Screen.currentResolution.width && resoluciones[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        DropdownResoluciones.AddOptions(options);
        DropdownResoluciones.value = currentResolutionIndex;
        DropdownResoluciones.RefreshShownValue();

    }
    public void PonerFullscreen(int a)
    {
        Resolution resolucion = Screen.currentResolution;
        bool full = true;

        if (a == 0)
        {
            full = true;
            Resolution resolution = Screen.currentResolution;
            Screen.SetResolution(resolution.width, resolution.height, full);
        }
        if(a == 1)
        {
            full = false;
            Resolution resolution = Screen.currentResolution;
            Screen.SetResolution(resolution.width, resolution.height, full);
        }
    }
    public void PonerResolucion(int resolutionIndex)
    {
        Resolution resolucion = resoluciones[resolutionIndex];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }
    public void CambiandoMaster(float volumen)
    {
        Master.SetFloat("MasterVolumen", volumen);
    }
    public void CambiandoMusica(float volumen)
    {
        Music.audioMixer.SetFloat("MusicVolumen", volumen);
    }
    public void CambiandoSFX(float volumen)
    {
        SFX.audioMixer.SetFloat("SFXVolumen", volumen);
    }


    //Funciones mas tecnicas relacionadas con escenas y .exe
    public void CargarEscenaPoblado()
    {
        SceneManager.LoadScene(1);
    }
    public void CerrarJuego()
    {
        Application.Quit();
    }

    private void Start()
    {
        CambiandoResoluciones();
    }

}

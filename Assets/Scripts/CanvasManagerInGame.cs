using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManagerInGame : MonoBehaviour {

    public GameObject PanelPausa;
    public GameObject PanelOpciones;
    public GameObject PanelControles;
    public GameObject PanelMenuPrincipal;
    public GameObject PanelSalir;

    public GameObject SubPanelSonido;
    public GameObject SubPanelGraficos;
    public GameObject SubPanelCrosshair;

    public Animator AnimacionCrosshair;

    public TMP_Dropdown DropdownGraficos;
    public TMP_Dropdown DropdownResoluciones;
    public TMP_Dropdown DropdownFullscreen;

    Resolution[] resoluciones;
    bool Pausado = false;

    //Funciones relacionadas con volver al menu principal, salir y resumir la partida
    public void MenuPausa()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Pausado == false)
        {
            Time.timeScale = 0;
            Pausado = true;
            PanelPausa.SetActive(true);
            Cursor.visible = true;
            //Apagar crosshair

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Pausado == true)
        {
            Time.timeScale = 1;
            Pausado = false;
            Cursor.visible = false;

            PanelPausa.SetActive(false);
            PanelOpciones.SetActive(false);
            PanelControles.SetActive(false);
            PanelControles.SetActive(false);
            PanelMenuPrincipal.SetActive(false);
            PanelSalir.SetActive(false);
            SubPanelSonido.SetActive(false);
            SubPanelGraficos.SetActive(false);
            SubPanelCrosshair.SetActive(false);
            //Encender crosshair
        }
    }
    public void ResumeJuego()
    {
        Time.timeScale = 1;
        Pausado = false;
        Cursor.visible = true;

        PanelPausa.SetActive(false);
        PanelOpciones.SetActive(false);
        PanelControles.SetActive(false);
        PanelControles.SetActive(false);
        PanelMenuPrincipal.SetActive(false);
        PanelSalir.SetActive(false);
        SubPanelSonido.SetActive(false);
        SubPanelGraficos.SetActive(false);
        SubPanelCrosshair.SetActive(false);
        //Encender crosshair
    }
    public void SalirDelJuego()
    {
        Application.Quit();
    }
    public void CargaMenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }

    //Abre los paneles indicados y cierra los que no deben estar abierto
    public void OnPanelOpcionesTrue()
    {
       if(PanelOpciones.activeSelf == false)
        {
            PanelOpciones.SetActive(true);
            PanelPausa.SetActive(false);
        }
    }
    public void OnPanelOpcionesFalse()
    {
        if(PanelOpciones.activeSelf == true)
        {
            PanelOpciones.SetActive(false);
            PanelPausa.SetActive(true);
        }
    }
    public void OnPanelControlesTrue()
    {
        if(PanelControles.activeSelf == false)
        {
            PanelControles.SetActive(true);
            PanelPausa.SetActive(false);
        }
    }
    public void OnPanelControlesFalse()
    {
        if (PanelControles.activeSelf == true)
        {
            PanelControles.SetActive(false);
            PanelPausa.SetActive(true);
        }
    }
    public void OnPanelMenuPrincipalTrue()
    {
        if(PanelMenuPrincipal.activeSelf == false)
        {
            PanelMenuPrincipal.SetActive(true);
            PanelPausa.SetActive(false);
        }
    }
    public void OnPanelMenuPrincipalFalse()
    {
        if(PanelMenuPrincipal.activeSelf == true)
        {
            PanelMenuPrincipal.SetActive(false);
            PanelPausa.SetActive(true);
        }
    }
    public void OnPanelSalirTrue()
    {
        if(PanelSalir.activeSelf == false)
        {
            PanelSalir.SetActive(true);
            PanelPausa.SetActive(false);
        }
    }
    public void OnPanelSalrFalse()
    {
        if(PanelSalir.activeSelf == true)
        {
            PanelSalir.SetActive(false);
            PanelPausa.SetActive(true);
        }
    }

    //Abre y cierra los submenus
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

    //Funciones de las opciones que incluye el juego
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
    public void PonerFullscreen()
    {
        Resolution resolucion = Screen.currentResolution;

        if (DropdownFullscreen.value == 0)
        {
            Screen.fullScreen = true;
        }
        if (DropdownFullscreen.value == 1)
        {
            Screen.fullScreen = false;
        }
    }
    public void PonerResolucion(int resolutionIndex)
    {
        Resolution resolucion = resoluciones[resolutionIndex];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }


    private void Start()
    {
        CambiandoResoluciones();
    }

    void Update () {

        if(Input.GetKeyDown(KeyCode.V))
        {
            AnimacionCrosshair.SetBool("AnimacionCrosshair", true);
        }


        MenuPausa();
	}
}

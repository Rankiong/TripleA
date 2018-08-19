using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class CanvasManagerInGame : MonoBehaviour {

    public static CanvasManagerInGame Instance;
    ControlPlayer controlPlayer;

    public AudioMixer Master;
    public AudioMixerGroup Music;
    public AudioMixerGroup SFX;

    public GameObject PanelPausa;
    public GameObject PanelOpciones;
    public GameObject PanelControles;
    public GameObject PanelMenuPrincipal;
    public GameObject PanelSalir;
    public GameObject PanelCrosshair;
    public Image PanelDesvanecimiento;
    public GameObject PanelFinal;
    public GameObject PanelUsarObjetos;
    public GameObject PanelSinMateriales;

    public Image Puntas;
    public Image Triangulo;
    public Image Puntas2;
    public Image Triangulo2;

    public Slider Sensibilidad;

    public GameObject SubPanelSonido;
    public GameObject SubPanelGraficos;
    public GameObject SubPanelCrosshair;

    public Animator AnimacionCrosshair;

    //public GameObject Pergamino1;
    //public GameObject Pergamino2;
    //public GameObject Pergamino3;
    //public ParticleSystem Particulas1;
    //public ParticleSystem Particulas2;
    //public ParticleSystem Particulas3;
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject Panel4;
    public GameObject Panel5;
    public GameObject Panel6;

    public TMP_Dropdown DropdownGraficos;
    public TMP_Dropdown DropdownResoluciones;
    public TMP_Dropdown DropdownFullscreen;
    public TMP_Dropdown DropdrownCrossahair;

    Resolution[] resoluciones;
    public bool Pausado = false;
    bool ComprobadorPergaminos = false;
    bool Comprobador1 = false;
    bool Comprobador2 = false;
    bool Comprobador3 = false;

    //Funciones relacionadas con volver al menu principal, salir y resumir la partida
    public void MenuPausa()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Pausado == false)
        {
            Time.timeScale = 0;
            Pausado = true;
            PanelPausa.SetActive(true);
            Cursor.visible = true;
            PanelCrosshair.SetActive(false);

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
            PanelCrosshair.SetActive(true);
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
        PanelCrosshair.SetActive(false);
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
        if (a == 1)
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
    public void CambiandoCrosshair()
    {
        if(DropdrownCrossahair.value == 0)
        {
            Puntas.color = Color.red;
            Triangulo.color = new Color(1, 0, 0, 0);
            Puntas2.color = Color.red;
            Triangulo2.color = new Color(1, 0, 0, 0);
        }
        if(DropdrownCrossahair.value == 1)
        {
            Puntas.color = Color.blue;
            Triangulo.color = new Color(0, 0, 1, 0);
            Puntas2.color = Color.blue;
            Triangulo2.color = new Color(0, 0, 1, 0);
        }
        if(DropdrownCrossahair.value == 2)
        {
            Puntas.color = Color.cyan;
            Triangulo.color = new Color(0, 1, 1, 0);
            Puntas2.color = Color.cyan;
            Triangulo2.color = new Color(0, 1, 1, 0);
        }
        if(DropdrownCrossahair.value == 3)
        {
            Puntas.color = Color.green;
            Triangulo.color = new Color(0, 1, 0, 0);
            Puntas2.color = Color.green;
            Triangulo2.color = new Color(0, 1, 0, 0);
        }
        if(DropdrownCrossahair.value == 4)
        {
            Puntas.color = Color.yellow;
            Triangulo.color = new Color(1, 0.92f, 0.016f, 0);
            Puntas2.color = Color.yellow;
            Triangulo2.color = new Color(1, 0.92f, 0.016f, 0);
        }
        if(DropdrownCrossahair.value == 5)
        {
            Puntas.color = Color.black;
            Triangulo.color = new Color(0, 0, 0, 0);
            Puntas2.color = Color.black;
            Triangulo2.color = new Color(0, 0, 0, 0);
        }
        if(DropdrownCrossahair.value == 6)
        {
            Puntas.color = Color.white;
            Triangulo.color = new Color(1, 1, 1, 0);
            Puntas2.color = Color.white;
            Triangulo2.color = new Color(1, 1, 1, 0);
        }
    }
    public void CambiandoSensibilidad()
    {
        controlPlayer.sensibilidad = Sensibilidad.value;
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

    //Funciones de paneles importantes de informacion
    //public void PergaminosControl()
    //{

    //    if(Pergamino1.activeSelf == false && Comprobador1 == false)
    //    {
    //        StartCoroutine("PergaminoCorrutinaUno");
    //        Particulas1.Stop();
    //    }
    //    if (Pergamino2.activeSelf == false && Comprobador2 == false)
    //    {
    //        StartCoroutine("PergaminoCorrutinaUno");
    //        Particulas2.Stop();
    //    }
    //    if (Pergamino3.activeSelf == false && Comprobador3 == false)
    //    {
    //        StartCoroutine("PergaminoCorrutinaUno");
    //        Particulas3.Stop();
    //    }
    //}

    public void Instanciar()
    {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else if (this != Instance)
            {
                Destroy(this.gameObject);
            }
    }

    public void Desvanecimiento(float tiempo)
    {
            Color color = PanelDesvanecimiento.color;
            color.a += Time.deltaTime * tiempo;
            PanelDesvanecimiento.color = color;
    }

    //Corrutinas
    //IEnumerator PergaminoCorrutinaUno()
    //{
    //    if(Pergamino1.activeSelf == false && Comprobador1 == false)
    //    {
    //        Comprobador1 = true;
    //        Panel5.SetActive(true);
    //        yield return new WaitForSeconds(3f);
    //        Panel5.SetActive(false);
    //    }
    //    if(Pergamino2.activeSelf == false && Comprobador2 == false)
    //    {
    //        Comprobador2 = true;
    //        Panel6.SetActive(true);
    //        yield return new WaitForSeconds(3f);
    //        Panel6.SetActive(false);
    //    }
    //    if(Pergamino3.activeSelf == false && Comprobador3 == false)
    //    {
    //        Comprobador3 = true;
    //        Panel2.SetActive(true);
    //        yield return new WaitForSeconds(3f);
    //        Panel2.SetActive(false);
    //    }

    //}
    IEnumerator ComienzoHistoria()
    {
        Panel1.SetActive(true);
        yield return new WaitForSeconds(5f);
        Panel1.SetActive(false);
    }

    private void Awake()
    {
        this.Instanciar();
        controlPlayer = FindObjectOfType<ControlPlayer>();
    }

    private void Start()
    {
        StartCoroutine("ComienzoHistoria");
        CambiandoResoluciones();
    }

    void Update () {

        CambiandoSensibilidad();
        CambiandoCrosshair();
        MenuPausa();
        //PergaminosControl();

        if(Input.GetKey(KeyCode.V) && Input.GetKey(KeyCode.B))
        {
            SceneManager.LoadScene(2);
        }
    }
}

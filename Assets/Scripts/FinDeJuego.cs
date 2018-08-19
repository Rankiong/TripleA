using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinDeJuego : MonoBehaviour {

    public static FinDeJuego findejuego;
    CanvasManagerInGame canvasmanageringame = CanvasManagerInGame.Instance;
    GameManager gamemanager = GameManager.Instance;
    ControlPlayer controlPlayer;
    bool Comprobador = false;

    private void Awake()
    {
        controlPlayer = FindObjectOfType<ControlPlayer>();
        findejuego = this;

        //if (gamemanager.AnimacionCrosshair == null)
        //{
        //    canvasmanageringame.PanelCrosshair.GetComponentInChildren<Animator>();
        //}

        if (gamemanager.CamaraPlayer == null)
        {
            gamemanager.CamaraPlayer = FindObjectOfType<Camera>();
        }

        controlPlayer.transform.position = new Vector3(1262.34f, 8.16f, 1218.6f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Comprobador = true;
            controlPlayer.salto = 0;
            controlPlayer.andar = 0;
            controlPlayer.correr = 0;
        }
    }

    private void Update()
    {
        //if(canvasmanageringame.PanelDesvanecimiento.GetComponent<Color>().a == 255)
        //{
        //    SceneManager.LoadScene(0);
        //}

        if(Comprobador == true)
        {
            canvasmanageringame.Desvanecimiento(0.5f);
            canvasmanageringame.PanelCrosshair.SetActive(false);
        }

        if (canvasmanageringame.PanelDesvanecimiento.color == Color.black)
        {
            canvasmanageringame.PanelFinal.SetActive(true);
            if (Input.anyKey)
            {
                Application.Quit();
            }
        }

    }
}

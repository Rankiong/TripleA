using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZonePinchos : MonoBehaviour {

    public delegate void _CuandoPlayerMuere();
    public static event _CuandoPlayerMuere CuandoPlayerMuere;

    public Vector3 PosicionInical;


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.transform.position = PosicionInical;
            if (CuandoPlayerMuere != null)
                CuandoPlayerMuere();
        }
    }
}

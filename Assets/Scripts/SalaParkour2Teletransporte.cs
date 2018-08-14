﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalaParkour2Teletransporte : MonoBehaviour {

    public Vector3 PosicionTeletransporte;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = PosicionTeletransporte;
        }
    }
}

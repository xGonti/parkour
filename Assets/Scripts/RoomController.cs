﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RoomController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    int sceneIndex;

    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }
    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }
    public override void OnJoinedRoom()
    {
        StartGame();
    }
    void StartGame()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            print("starting game");
            PhotonNetwork.LoadLevel(sceneIndex);
        }
    }
}



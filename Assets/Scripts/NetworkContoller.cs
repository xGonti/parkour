using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class NetworkContoller : MonoBehaviourPunCallbacks
{
    [SerializeField]
    Button startButton;

    private void Start()
    {
        startButton.interactable = false;
        PhotonNetwork.ConnectUsingSettings();
        print("Joinar..");
    }

    public override void OnConnectedToMaster()
    {
        print("Joinade servern i" + PhotonNetwork.CloudRegion);
        startButton.interactable = true;
        PhotonNetwork.AutomaticallySyncScene = true;

    }

}


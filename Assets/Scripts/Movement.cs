using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Movement : MonoBehaviour //Theo och Michal
{
    public float MovementSpeed = 1; //Adjustable rörelse hastighet 
    public float JumpForce = 1; //Adjustable hoppande 
    private Rigidbody2D _rigidbody;
    CameraFollow follow;
    PhotonView view;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>(); // Generisk kod!!!
        view = GetComponent<PhotonView>();
        if (view.IsMine)
        {
            follow = FindObjectOfType<CameraFollow>();
            follow.target = transform;
        }
    }

    private void Update()
    {
        if (view.IsMine)
        {
            if (PhotonNetwork.PlayerList.Length > 1)
            {
                print("yay");
            }
            var movement = Input.GetAxis("Horizontal");
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MovementSpeed; //Gör så att du kan röra på dig side to side 


            if (!Mathf.Approximately(0, movement))
            {
                transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity; //När du går åt ett håll roterar din charactär åt det hållet 
            }


            if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f) //om du trycker på hoppa så hoppar du. + ser till att du inte kan dubbel hoppa 
            {
                _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            }
        }
    }
}
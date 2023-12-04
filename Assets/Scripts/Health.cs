using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEditor;
using UnityEngine.UIElements;
//using UnityEditor.EditorTools;

public class Health : MonoBehaviour
{
    public bool isLocalPlayer;
    public int health;
    public bool hasBlue;
    public bool hasRed;
    public GameObject flagBlue;
    public GameObject flagRed;
    public Vector3 flagPosition;

    

    [PunRPC]
    public void TakeDamage(int _damage)
    {
        health -= _damage;

        if(health <= 0)
        {
            if(isLocalPlayer)
            {
                RoomManager.instance.SpawnPlayer();
            }
            //if player has a flag, respawn it
            if (hasBlue)
            {
                Instantiate(flagBlue, flagPosition, Quaternion.identity);
                hasBlue = false;
            }
            if (hasRed)
            {
                Instantiate(flagRed, flagPosition, Quaternion.identity);
                hasRed = false;
            }
            Destroy(gameObject);
        }
    }
}

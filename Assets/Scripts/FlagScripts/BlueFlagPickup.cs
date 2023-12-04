using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BlueFlagPickup : MonoBehaviour
{
    
    public Vector3 startingPosition;
    void Start()
    {
        startingPosition = transform.position;
    }

    
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.layer == LayerMask.NameToLayer("RedTeam"))
        {
            Health health = player.GetComponent<Health>();
            Debug.Log("collided with player");
            transform.parent = player.transform;
            transform.localPosition = new Vector3(-.19f, .59f, -.22f);
            health.hasBlue = true;
            health.hasRed = false;
            health.flagPosition = startingPosition;
        }
    }

    public void DropFlag()
    {
        transform.parent = null;
       
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFlagPickup : MonoBehaviour
{
    public bool hasBeenCaptured = false;
    public Vector3 startingPosition;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.layer == LayerMask.NameToLayer("BlueTeam"))
        {
            Health health = player.GetComponent<Health>();
            Debug.Log("collided with blue player");
            transform.parent = player.transform;
            transform.localPosition = new Vector3(-.19f, .59f, -.22f);
            health.hasBlue = false;
            health.hasRed = true;
            health.flagPosition = startingPosition;
        }
    }

    public void DropFlag()
    {
        transform.parent = null;
    }
}

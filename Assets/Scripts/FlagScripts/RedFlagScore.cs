using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFlagScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("BlueScore"))
        {
            Debug.Log("blue scored");
            RoomManager.instance.blueTeamScore++;
            Debug.Log(RoomManager.instance.blueTeamScore);
            Destroy(gameObject);
        }
    }
}

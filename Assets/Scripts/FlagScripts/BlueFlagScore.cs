using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueFlagScore : MonoBehaviour
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
        if (collision.gameObject.layer == LayerMask.NameToLayer("RedScore"))
        {
            Debug.Log("scored");
            RoomManager.instance.redTeamScore++;
            Debug.Log(RoomManager.instance.redTeamScore);
            Destroy(gameObject);
        }
    }
}

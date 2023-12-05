using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public RoomManager roomManager;
    public GameObject redWins;
    public GameObject blueWins;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (roomManager.redTeamScore == 3)
        {
            redWins.SetActive(true);
        }
        else if (roomManager.blueTeamScore == 3)
        {
            blueWins.SetActive(true);
        }
    }
}

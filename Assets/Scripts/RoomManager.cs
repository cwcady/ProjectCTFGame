using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;
using TMPro;

public class RoomManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject bluePlayerPrefab;
    public GameObject redPlayerPrefab;
    public GameObject redFlagPrefab;
    public GameObject blueFlagPrefab;

    public Transform[] spawnPointsRed;
    public Transform[] spawnPointsBlue;

    public GameObject roomCamera;
    public GameObject teamSelectUI;
    public GameObject connectingUI;
    public GameObject scoreUI;

    [SerializeField] TextMeshProUGUI redScoreText;
    [SerializeField] TextMeshProUGUI blueScoreText;
    public int redTeamScore = 0;
    public int blueTeamScore = 0;

    private int teamNumber = 0; //start on no team

    public static RoomManager instance;

    public string roomNameToJoin = "test";

    private void Awake()
    {
        SetScore();
        instance = this;
    }

    public void PickTeam(int _team)
    {
        teamNumber = _team;
    }

    public void JoinRedTeamButtonPressed()
    {
        Debug.Log("Connecting");
        teamNumber = 1;
        PhotonNetwork.JoinOrCreateRoom(roomNameToJoin, null, null);
        teamSelectUI.SetActive(false);
        connectingUI.SetActive(true);
    }
    public void JoinBlueTeamButtonPressed()
    {
        Debug.Log("Connecting");
        teamNumber = 2;
        PhotonNetwork.JoinOrCreateRoom(roomNameToJoin, null, null);
        teamSelectUI.SetActive(false);
        connectingUI.SetActive(true);
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            redTeamScore += 1;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            blueTeamScore += 1;
        }
        SetScore();
    }


   

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Joined Room");

        roomCamera.SetActive(false);

        SpawnPlayer();
    }


    public void SpawnPlayer()
    {
        if (teamNumber == 1)
        {
            Transform spawnPointRed = spawnPointsRed[UnityEngine.Random.Range(0, spawnPointsRed.Length)];
            player = redPlayerPrefab;
            GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPointRed.position, Quaternion.identity);
            _player.GetComponent<PlayerSetup>().IsLocalPlayer();
            _player.GetComponent<Health>().isLocalPlayer = true;
            _player.GetComponent<PhotonView>().RPC("SetTeam", RpcTarget.All, teamNumber);
            scoreUI.SetActive(true);

        }
        if(teamNumber == 2)
        {
            Transform spawnPointBlue = spawnPointsBlue[UnityEngine.Random.Range(0, spawnPointsBlue.Length)];
            player = bluePlayerPrefab;
            GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPointBlue.position, Quaternion.identity);
            _player.GetComponent<PlayerSetup>().IsLocalPlayer();
            _player.GetComponent<Health>().isLocalPlayer = true;
            _player.GetComponent<PhotonView>().RPC("SetTeam", RpcTarget.All, teamNumber);
            scoreUI.SetActive(true);
        }
    }

    public void SetScore()
    {
        /*Hashtable gameScore = new Hashtable();
        gameScore["Blue Score"] = blueTeamScore;
        gameScore["Red Score"] = redTeamScore;*/
        redScoreText.text = "Red Team Score: " + redTeamScore;
        blueScoreText.text = "Blue Team Score: " + blueTeamScore;
    }
   
}

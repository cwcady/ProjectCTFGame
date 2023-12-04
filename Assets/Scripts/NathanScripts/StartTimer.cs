using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float startTime;
    public GameObject endText;
    private PreTimer preTimer;
    public float time;

    void Awake()
    {
        //preTimer = a.GetComponent<PreTimer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //preTimer = a.GetComponent<PreTimer>();
    }

    // Update is called once per frame
    void Update()
    {
        time = PreTimer.timeIndex.remainingTime;
        if (time == 0)
        {
            timerText.gameObject.SetActive(true);
            if (startTime > 0)
            {
                startTime -= Time.deltaTime;
            }
            else if (startTime < 0)
            {
                startTime = 0;
                timerText.color = Color.red;
                //timerText.enabled = false;
                endText.SetActive(true);
                endText.GetComponent<Animator>().SetTrigger("end");
            }
            int minutes = Mathf.FloorToInt(startTime / 60);
            int seconds = Mathf.FloorToInt(startTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}

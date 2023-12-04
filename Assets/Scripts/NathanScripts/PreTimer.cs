using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PreTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] public float remainingTime;
    public GameObject startImg;
    public GameObject highlight;
    public GameObject trapMenu;
    public float delay = 3;
    float t;
    // Start is called before the first frame update
    public static PreTimer timeIndex;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            //timerText.color = Color.red;
            timerText.enabled = false;
            startImg.GetComponent<Animator>().SetTrigger("start");

            highlight.SetActive(false);
            trapMenu.SetActive(false);
            /*t += Time.deltaTime;
            if (t > delay)
            {
                PreGame();
            }*/
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    private void Awake() {
        timeIndex = this;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTrap : MonoBehaviour
{
    public GameObject ghost;
    public GameObject placed;
    public GameObject trap1;
    public GameObject trap2;
    public GameObject trap3;
    public GameObject trap4;

    public int tNum;
    public int totalTraps = 10;
    private float x;
    // Start is called before the first frame update
    void Start()
    {
        //placed = trap1;
        //tNum = 1;
        //num = GameObject.Find("trapNum").GetComponent<SelectTrap>().trapNum;
    }

    // Update is called once per frame
    void Update()
    {
        x = PreTimer.timeIndex.remainingTime;
        tNum = SelectTrap.index.trapNum;
        if (tNum == 1)
        {
            placed = trap1;
            //Debug.Log(tNum);
        }
        else if (tNum == 2)
        {
            placed = trap2;
        }
        else if (tNum == 3)
        {
            placed = trap3;
        }
        else if (tNum == 4)
        {
            placed = trap4;
        }
        if (totalTraps > 0)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                ghost.transform.position = hit.point;
                if (Input.GetKeyDown("e"))
                {
                    totalTraps -= 1;
                    Instantiate(placed, ghost.transform.position, ghost.transform.rotation);
                }
            }
        }
        else {
            ghost.SetActive(false);
        }
        /*if (x == 0) {
            totalTraps = 0;
            ghost.SetActive(false);
        }*/
    }
}

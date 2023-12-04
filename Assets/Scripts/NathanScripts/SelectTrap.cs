using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTrap : MonoBehaviour
{
    public GameObject lineA;
    public GameObject lineM;
    public GameObject lineV;
    public GameObject lineH;

    //public GameObject trap;
    public int trapNum;
    public static SelectTrap index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void DisableHighlight(){
		lineA.SetActive(false);
		lineM.SetActive(false);
		lineV.SetActive(false);
		lineH.SetActive(false);
	}

    public void Button1(){
        DisableHighlight();
	    lineA.SetActive(true);
	}
    public void Button2(){
        DisableHighlight();
	    lineM.SetActive(true);
	}
    public void Button3(){
        DisableHighlight();
	    lineV.SetActive(true);
	}
    public void Button4(){
        DisableHighlight();
	    lineH.SetActive(true);
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1")) {
            Button1();
            trapNum = 1;
            //trap.GetComponent<PlaceTrap>().placed;
        }
        else if (Input.GetKeyDown("2")) {
            Button2();
            trapNum = 2;
        }
        else if (Input.GetKeyDown("3")) {
            Button3();
            trapNum = 3;
        }
        else if (Input.GetKeyDown("4")) {
            Button4();
            trapNum = 4;
        }
    }

    private void Awake() {
        index = this;
    }
}

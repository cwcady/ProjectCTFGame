using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("UI Menu");
        }
    }

    /*
    public void onMenuButtonPressed()
    {
        SceneManager.LoadScene("UI Menu", LoadSceneMode.Additive);
    }*/
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    public bool isLocalPlayer;
    public float health;
    private float maxHealth = 100f;
    public bool hasBlue;
    public bool hasRed;
    public GameObject flagBlue;
    public GameObject flagRed;
    public Vector3 flagPosition;
    public TextMeshProUGUI healthText;
    public Image frontBar;
   // public Image backBar;
    private float originalHealthBarSize;
    public RectTransform healthbar;


    private void Start()
    {
        originalHealthBarSize = healthbar.sizeDelta.x;
    }

    private void Update()
    {
        
    }
    /*
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);

        //UpdateHealthUI();
        healthText.text = health + "/100";
    }*/
    /*
    public void UpdateHealthUI()
    {
        //Debug.Log(health);
        float fillf = frontBar.fillAmount;
        float fillb = backBar.fillAmount;
        float hFraction = health / maxHealth;
        if (fillb > hFraction)
        {
            frontBar.fillAmount = hFraction;
            backBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percent = lerpTimer / chipSpeed;
            percent = percent * percent;
            backBar.fillAmount = Mathf.Lerp(fillb, hFraction, percent);
        }
        if (fillf < hFraction)
        {
            backBar.fillAmount = hFraction;
            backBar.color = Color.green;
            lerpTimer += Time.deltaTime;
            float percent = lerpTimer / chipSpeed;
            percent = percent * percent;
            frontBar.fillAmount = Mathf.Lerp(fillf, backBar.fillAmount, percent);
        }
    }
    */

    [PunRPC]
    public void TakeDamage(float _damage)
    {
       
        health -= _damage;
        Debug.Log(health);
        //healthbar.sizeDelta = new Vector2(originalHealthBarSize * health / 100f, healthbar.sizeDelta.y);
        frontBar.fillAmount = health / maxHealth;
        healthText.text = health + "/100";

        if (health <= 0)
        {
            if(isLocalPlayer)
            {
                RoomManager.instance.SpawnPlayer();
            }
            //if player has a flag, respawn it
            if (hasBlue)
            {
                Instantiate(flagBlue, flagPosition, Quaternion.identity);
                hasBlue = false;
            }
            if (hasRed)
            {
                Instantiate(flagRed, flagPosition, Quaternion.identity);
                hasRed = false;
            }
            Destroy(gameObject);
        }
    }

    
}

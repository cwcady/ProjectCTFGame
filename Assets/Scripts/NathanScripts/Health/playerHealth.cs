using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerHealth : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] public float  health;
    public float  lerpTimer;
    private float  maxHealth = 100f;
    private float  chipSpeed = 2f;
    public Image frontBar;
    public Image backBar;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        
        UpdateHealthUI();
        //health = h._currentHealth;
        if (Input.GetKeyDown(KeyCode.O))
        {
            TakeDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Heal(Random.Range(5, 10));
        }
        healthText.text = health + "/100";
    }

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

    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0;
    }

    public void Heal(float healAmount)
    {
        health += healAmount;
        lerpTimer = 0;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Projectile")) 
        {
            health -= 5;
            lerpTimer = 0;
        }
        else if (other.CompareTag("Bomb")) 
        {
            health -= 25;
            lerpTimer = 0;
        }
    }
}

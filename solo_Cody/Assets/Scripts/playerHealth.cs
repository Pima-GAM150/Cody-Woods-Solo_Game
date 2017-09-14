using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class playerHealth : MonoBehaviour {

    public float fullHealth;
    public GameObject deathFX;
    float currentHealth;

    playerController controlMovement;
    //hud variables
    public Slider healthSlider;
    public Image damageScreen;

    bool damaged = false;
    Color damagedColour = new Color(0f, 0f, 0f, 0.5f);
    float smoothColour = 5f;

	// Use this for initialization
	void Start () {
        currentHealth = fullHealth;

        controlMovement = GetComponent<playerController>();

        //hudd initialization
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;

        damaged = false; //<--this isn't required

	}
	
	// Update is called once per frame
	void Update () {

        if (damaged)
        {
            damageScreen.color = damagedColour;
        }else
        {
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColour * Time.deltaTime);
        }
        damaged = false;
		
	}
    public void addDamage(float damage)
    {
        if (damage <= 0) return;
        currentHealth -= damage;

        healthSlider.value = currentHealth;
        damaged = true;

        if (currentHealth <= 0)
        {
            makeDead();
        }
    }

    public void addHealth(float healthAmount)
    {
        currentHealth += healthAmount;
        if (currentHealth > fullHealth) currentHealth = fullHealth;
        healthSlider.value = currentHealth;
    }

    public void makeDead()
    {
        Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

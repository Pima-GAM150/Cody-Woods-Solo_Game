using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHeath : MonoBehaviour {
    public float enemyMaxHeath;
    public bool drops;
    public GameObject theDrop;
    float currentHealth;
	// Use this for initialization
	void Start () {
        currentHealth = enemyMaxHeath;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void addDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) makeDead();
    }
    void makeDead()
    {
        Destroy(gameObject);
        if (drops) Instantiate(theDrop, transform.position, transform.rotation);
    }
}

using UnityEngine;
using System.Collections;


public class HealthManager : WaveManager {
    public GUIText health;
    public int Health;
	// Use this for initialization
	void Start () {
        this.Health = 10;//Sets the player health
    }
	
	// Update is called once per frame
    void Update()
    {
        health.GetComponent<GUIText>().text = "Health: " + this.Health.ToString();//Diplays Health points
        if(this.Health==0)//Reload the level after player loses all Health points
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Enemy" && this.gameObject.tag=="Player") //CHecks if this player is hit by a fish
        {
            this.Health--;//Loses health upon being hit by a fish
        }
        else if (other.gameObject.tag == "Bullet" && this.gameObject.tag == "Enemy")//Checks if this is a fish and is hit by a bullet
        {
            this.Health--;//Fish loses health after hit by bullet
        }
    }
}

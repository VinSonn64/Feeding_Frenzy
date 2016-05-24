using UnityEngine;
using System.Collections;

public class Walls : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter(Collider other)//Blocks the bullets so the player can only hit the Fish once they enter the cage.
    {
        if(other.gameObject.tag=="Bullet")//Checks if a bullet hits the wall and removes it.
        {
            other.gameObject.SetActive(false);
        }
    }
}

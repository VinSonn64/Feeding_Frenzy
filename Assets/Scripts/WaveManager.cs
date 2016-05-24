using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour {
    //Prefabs of all enemy types
    public Rigidbody PrefabLVL1Fish;
    public Rigidbody PrefabLVL2Fish;
    public Rigidbody PrefabLVL3Fish;
    public Rigidbody PrefabSuperFish;
    //All the spawn points that the prefabs would instantiate from.
    public Transform Spawn1;
    public Transform Spawn2;
    public Transform Spawn3;
    public Transform Spawn4;
    public Transform Spawn5;
    public Transform Spawn6;
    public Transform Spawn7;
    public Transform Spawn8;

    public static int Kills;//Amount of kills for each wave, decreases for each fish that eneters a dead state

    bool spawning = false;//Bool checking if game is currently spawning enemies or not.

    public GUIText Enemies;//HUD for amount of enemies left on the current wave
    public GUIText WaveNum;//Text dsplaying which wave is on currently

    public enum Wave//Each state is a wave spawning enemies and waiting to start the next one
    { 
        Wave0 = 0,
        Wave1 = 1,
        Wave2 = 2,
        Wave3 = 3,
        Wave4 = 4,
        Wave5 = 5
    }

    private Wave currentWave;//the current wave instant

   void checkKills(int killTotal)//Checks if there are still enemies on the field
    { 
       if (currentWave== Wave.Wave0 && killTotal<=0)//checks if it's the first wave and no enemies left on the field
       {
           currentWave = Wave.Wave1;//move to next wave
           WaveNum.GetComponent<GUIText>().text = currentWave.ToString();//display next wave
           spawning = true;//allow spawning
       }

       else if (currentWave == Wave.Wave1 && killTotal <= 0)
       {
           currentWave = Wave.Wave2;//move to next wave
           WaveNum.GetComponent<GUIText>().text = currentWave.ToString();//display next wave
           spawning = true;
       }

       else if (currentWave == Wave.Wave2 && killTotal <= 0)
       {
           currentWave = Wave.Wave3;//move to next wave
           WaveNum.GetComponent<GUIText>().text = currentWave.ToString();//display next wave
           spawning = true;
       }
       else if (currentWave == Wave.Wave3 && killTotal <= 0)
       {
           currentWave = Wave.Wave4;//move to next wave
           WaveNum.GetComponent<GUIText>().text = currentWave.ToString();//display next wave
           spawning = true;
       }
       else if (currentWave == Wave.Wave4 && killTotal <= 0)
       {
           currentWave = Wave.Wave5;//move to next wave
           WaveNum.GetComponent<GUIText>().text = currentWave.ToString();//display next wave
           spawning = true;
       }
       else if (currentWave == Wave.Wave5 && killTotal <= 0)//Check if final wave and no enemies left
       {
           WaveNum.GetComponent<GUIText>().text = "You Won!!!!";//Display "you win"
       }

   }

	// Use this for initialization
	void Start () 
    {
        currentWave = Wave.Wave0;//Sets current wave to the first wave
        Kills = 4;//sets wave kill amount to 4
        WaveNum.GetComponent<GUIText>().text = currentWave.ToString();//Display the current wave
            Rigidbody FishInstance1; //Creates Instance instant
            FishInstance1 = Instantiate(PrefabLVL1Fish, Spawn1.position, Spawn1.rotation) as Rigidbody;//Instantiate a fish Prefab, it's location, and rotation
            Rigidbody FishInstance2;
            FishInstance2 = Instantiate(PrefabLVL1Fish, Spawn2.position, Spawn2.rotation) as Rigidbody;
            Rigidbody FishInstance3;
            FishInstance3 = Instantiate(PrefabLVL1Fish, Spawn3.position, Spawn3.rotation) as Rigidbody;
            Rigidbody FishInstance4;
            FishInstance4 = Instantiate(PrefabLVL1Fish, Spawn4.position, Spawn3.rotation) as Rigidbody;
            
	}
	
	// Update is called once per frame
	void Update () {
        Enemies.GetComponent<GUIText>().text = "Enemies: " + Kills.ToString();//Constantly displays how many enemies left
        checkKills(Kills);//Checks how any kills left
        if (spawning == true)//Once Kill=0, spawning is set true and will check which wave is on, run the function under which will instantiate 
            //all enemies, and will then stop spawning.
        {
            switch (currentWave)
            {
                case Wave.Wave1:
                    Wave1Spawn();
                    break;
                case Wave.Wave2:
                    Wave2Spawn();
                    break;
                case Wave.Wave3:
                    Wave3Spawn();
                    break;
                case Wave.Wave4:
                    Wave4Spawn();
                    break;
                case Wave.Wave5:
                    Wave5Spawn();
                    break;
            }
        }
	}

    //As game enters new wave state, a function specific to each wave will instantiate enemies determined below
    void Wave1Spawn()
    {
        Rigidbody FishInstance1; 
        FishInstance1 = Instantiate(PrefabLVL2Fish, Spawn1.position, Spawn1.rotation) as Rigidbody;
        Rigidbody FishInstance2;
        FishInstance2 = Instantiate(PrefabLVL2Fish, Spawn2.position, Spawn2.rotation) as Rigidbody;
        Rigidbody FishInstance3;
        FishInstance3 = Instantiate(PrefabLVL1Fish, Spawn3.position, Spawn3.rotation) as Rigidbody;
        Rigidbody FishInstance4;
        FishInstance4 = Instantiate(PrefabLVL1Fish, Spawn4.position, Spawn4.rotation) as Rigidbody;
       
        Kills = 4;//Sets amount of kills needed
        spawning = false;//Turns spawning off
    }
    void Wave2Spawn()
    {
        Rigidbody FishInstance1; //
        FishInstance1 = Instantiate(PrefabLVL2Fish, Spawn1.position, Spawn1.rotation) as Rigidbody;
        Rigidbody FishInstance2;
        FishInstance2 = Instantiate(PrefabLVL2Fish, Spawn2.position, Spawn2.rotation) as Rigidbody;
        Rigidbody FishInstance3;
        FishInstance3 = Instantiate(PrefabLVL2Fish, Spawn3.position, Spawn3.rotation) as Rigidbody;
        Rigidbody FishInstance5;
        FishInstance5 = Instantiate(PrefabLVL2Fish, Spawn5.position, Spawn4.rotation) as Rigidbody;
        Rigidbody FishInstance6;
        FishInstance6 = Instantiate(PrefabLVL3Fish, Spawn6.position, Spawn4.rotation) as Rigidbody;
        Kills = 5;
        spawning = false;
    }
    void Wave3Spawn()
    {
        Rigidbody FishInstance1; //
        FishInstance1 = Instantiate(PrefabLVL2Fish, Spawn1.position, Spawn1.rotation) as Rigidbody;
        Rigidbody FishInstance2;
        FishInstance2 = Instantiate(PrefabLVL2Fish, Spawn2.position, Spawn2.rotation) as Rigidbody;
        Rigidbody FishInstance3;
        FishInstance3 = Instantiate(PrefabLVL1Fish, Spawn3.position, Spawn3.rotation) as Rigidbody;
        Rigidbody FishInstance5;
        FishInstance5 = Instantiate(PrefabLVL3Fish, Spawn5.position, Spawn3.rotation) as Rigidbody;
        Rigidbody FishInstance6;
        FishInstance6 = Instantiate(PrefabLVL3Fish, Spawn6.position, Spawn4.rotation) as Rigidbody;
        Rigidbody FishInstance7;
        FishInstance7 = Instantiate(PrefabLVL2Fish, Spawn7.position, Spawn4.rotation) as Rigidbody;

        Kills = 6;
        spawning = false;
    }
    void Wave4Spawn()
    {
        Rigidbody FishInstance1; //
        FishInstance1 = Instantiate(PrefabLVL2Fish, Spawn1.position, Spawn1.rotation) as Rigidbody;//
        Rigidbody FishInstance2;
        FishInstance2 = Instantiate(PrefabLVL2Fish, Spawn2.position, Spawn2.rotation) as Rigidbody;
        Rigidbody FishInstance3;
        FishInstance3 = Instantiate(PrefabSuperFish, Spawn3.position, Spawn3.rotation) as Rigidbody;
        Rigidbody FishInstance4;
        FishInstance4 = Instantiate(PrefabLVL3Fish, Spawn4.position, Spawn4.rotation) as Rigidbody;
        Rigidbody FishInstance5;
        FishInstance5 = Instantiate(PrefabLVL3Fish, Spawn5.position, Spawn3.rotation) as Rigidbody;
        Rigidbody FishInstance6;
        FishInstance6 = Instantiate(PrefabLVL3Fish, Spawn6.position, Spawn4.rotation) as Rigidbody;
        Rigidbody FishInstance7;
        FishInstance7 = Instantiate(PrefabLVL2Fish, Spawn7.position, Spawn3.rotation) as Rigidbody;
        Rigidbody FishInstance8;
        FishInstance8 = Instantiate(PrefabLVL2Fish, Spawn8.position, Spawn4.rotation) as Rigidbody;
        Kills = 8;
        spawning = false;
    }
    void Wave5Spawn()
    {
        Rigidbody FishInstance1; //
        FishInstance1 = Instantiate(PrefabLVL2Fish, Spawn1.position, Spawn1.rotation) as Rigidbody;//
        Rigidbody FishInstance2;
        FishInstance2 = Instantiate(PrefabLVL3Fish, Spawn2.position, Spawn2.rotation) as Rigidbody;
        Rigidbody FishInstance3;
        FishInstance3 = Instantiate(PrefabLVL3Fish, Spawn3.position, Spawn3.rotation) as Rigidbody;
        Rigidbody FishInstance4;
        FishInstance4 = Instantiate(PrefabLVL2Fish, Spawn4.position, Spawn4.rotation) as Rigidbody;
        Rigidbody FishInstance5;
        FishInstance5 = Instantiate(PrefabLVL2Fish, Spawn5.position, Spawn3.rotation) as Rigidbody;
        Rigidbody FishInstance6;
        FishInstance6 = Instantiate(PrefabLVL3Fish, Spawn6.position, Spawn4.rotation) as Rigidbody;
        Rigidbody FishInstance7;
        FishInstance7 = Instantiate(PrefabSuperFish, Spawn7.position, Spawn3.rotation) as Rigidbody;
        Rigidbody FishInstance8;
        FishInstance8 = Instantiate(PrefabSuperFish, Spawn8.position, Spawn4.rotation) as Rigidbody;
        Kills = 8;
        spawning = false;
    }
}

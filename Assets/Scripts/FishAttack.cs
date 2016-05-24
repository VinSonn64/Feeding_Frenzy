using UnityEngine;
using System.Collections;


public class FishAttack : HealthManager {
    public GameObject LeftEye;
    public GameObject RightEye;

    NavMeshAgent agent; //Give pathfinding mentality to Fish
    
    public float num = 10; //Initiates the fish with a number that won't immediately toogle the fish to Attacking State

    public enum Status //States
    {
        Seeking = 0,//Fish is wandering around without a target
        Attacking = 1,//Fish have target position and moves towards it
        Dead = 2//Fish has no health, gets destroyed, and updates the kills
    }

    private Status status = Status.Seeking;//Initializes the Fish state as Seeking

    void checkStatus()//Checks to see if the Fish has the condition to attack
    {
        if (num > 1)//if the Randomly selected number is greater than 1, it will keep Seeking
        { status = Status.Seeking; }

        else if (num<1)//if the Randomly selected number is less than 1, it sets the Fish to Attacking
        { status = Status.Attacking; }

        if(this.Health<=0)//Checks if this fish has lost all health, sets it to dead
        {
            status = Status.Dead;
            
        }

    }

	
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
       if(this.gameObject.name=="LVL1Fish(Clone)")//Gives LVL1 FIsh little health, dies in one hit
        {
            this.Health = 1;
        }
        else if(this.gameObject.name=="LVL2Fish(Clone)")//LVL2 FIsh has little more health, takes a few more hits
        {
            this.Health = 4;
        }
       else if (this.gameObject.name == "LVL3Fish(Clone)")//Stronger fish, may take about five hits
       {
           this.Health = 8;
       }
       else if (this.gameObject.name == "SuperFish(Clone)")//Massive health for largest fish.
       {
           this.Health = 30;
       }
    }

	// Update is called once per frame
	void Update () {
       
        checkStatus();//checks the state of the Fish in each frame
        switch (status)
        {
            case Status.Seeking://Seek State as long as the random number is over 1
                num = Random.Range(0.0f, 500f);//Each frame will pick a random number while the Fish is till Seeking
                Debug.Log("Fish is Seeking");
                break;

            case Status.Attacking: //when the number eventually hits under 1, it sets the the Fish to the attack State 
                Debug.Log("Fish is Attacking");
                Attack();//The Attack Function
                break;
            case Status.Dead:
                Debug.Log("Fish is Kill");
                Death();
                break;

        }
	}

    void Attack()
    {
        
                LeftEye.gameObject.GetComponent<Renderer>().material.color = Color.red;//Change Left Eye Red when attacking
                RightEye.gameObject.GetComponent<Renderer>().material.color = Color.red;//Change Right Eye Red when attacking
                agent.SetDestination(new Vector3(0f,0f,0f));//Fish head towards the center where the player is located
    }


    void OnTriggerEnter( Collider other)
    {
        if (other.gameObject.tag == "Player")//Checks to see if the fish hits the player
        {
           this.gameObject.SetActive(false);//Turns fish off once hitting the player
           Kills--;
        }

        else if (other.gameObject.tag == "Bullet")//Checks to see if the fish hits a bullet
        {
            this.Health--;//Fish loses one health after being shot
        }
    }
    void Death()
    {
        this.gameObject.SetActive(false);//Deactivates the fish
        Kills--;//Elimates one enemy

    }
}

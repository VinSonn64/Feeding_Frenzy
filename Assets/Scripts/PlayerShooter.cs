using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour {

    //Shooting Mechanic
    public Rigidbody bulletPrefab;//Prefab for bullet Note: One Prefab for player and another for turrets to avoid colliding with the shooter
    public Transform bulletTransform;//Location of the shooter

    // Use this for initialization
    void Start()
    {
        Cursor.visible = !Cursor.visible;//Makes mouse disappear
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1") && this.gameObject.tag == "Player")//Checks if the mouse click and Shooter is tagged as Player
        {
            Rigidbody bulletInstance; //Creates bullet instant
            bulletInstance = Instantiate(bulletPrefab, bulletTransform.position, bulletTransform.rotation) as Rigidbody;//Instantiate a bullet from the Player
            bulletInstance.AddForce(Camera.main.ScreenPointToRay(new Vector3(0.5f * Screen.width, 0.5f * Screen.height, 0f)).direction * 2000);//Pushes bullet in direction of player camera
        }

    }
    
}

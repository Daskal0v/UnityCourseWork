using UnityEngine;
using System.Collections;

public class EnemyCollisions : MonoBehaviour {
    //public Animator control;
    //public GameObject player;
    public float playerPushedX;
    public float playerPushedZ;

	// Use this for initialization
	void Start () {
        //player = GameObject.FindGameObjectWithTag("PlayerSprite");
        //control = player.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    void OnCollisionEnter(Collision playerCollision)
    {
        if (playerCollision.gameObject.tag == "Player")
        {
            playerCollision.gameObject.transform.position += new Vector3(playerPushedX, -1f * Time.deltaTime, playerPushedZ);
            //control.SetBool("Fall", true);
        }
    }
}

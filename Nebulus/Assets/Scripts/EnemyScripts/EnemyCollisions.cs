using UnityEngine;
using System.Collections;

public class EnemyCollisions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision playerCollision)
    {
        if (playerCollision.gameObject.tag == "Player")
        {
            playerCollision.gameObject.transform.position += new Vector3(2f, -1f * Time.deltaTime, 2f);
        }
    }
}

using UnityEngine;
using System.Collections;

public class WanderingEnemyScript : MonoBehaviour {

    //private Vector3 movingDirection = Vector3.left;
    public float speed;
    GameObject startPosition;
    GameObject endPosition;

	// Use this for initialization
	void Start () {
        startPosition = GameObject.FindGameObjectWithTag("StartPosition");
        endPosition = GameObject.FindGameObjectWithTag("EndPosition");
	}
	
	// Update is called once per frame
	void Update () {
        //transform.RotateTowards(transform.forward, targetDir, step, 0.0F);
        //gameObject.transform.Translate(movingDirection * Time.smoothDeltaTime * speed);
        gameObject.transform.RotateAround(Vector3.zero, Vector3.up, -speed * Time.deltaTime);
        if (gameObject.transform.position.x < endPosition.transform.position.x)
        {
            gameObject.transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime);
        }
        else if (gameObject.transform.position.x > startPosition.transform.position.x)
        {
            
            gameObject.transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime * -1);
        }
        //TODO: Movement of enemy
	}
}

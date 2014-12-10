using UnityEngine;
using System.Collections;

public class EnemyPingPongHorizontal : MonoBehaviour {

    private GameObject player;
    private Vector3 movingDirection = Vector3.up;
    private bool isAlive = true;
    public float standRange;
    public float attackRange;
    public float upperPosition;
    public float lowerPosition;
    public float speed;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(transform.position, player.transform.position);
        float step = speed * Time.deltaTime;

        if (dist < attackRange)
        {
            transform.LookAt(player.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
        
        gameObject.transform.Translate(movingDirection * Time.deltaTime * speed);

        if (gameObject.transform.position.y < lowerPosition)
        {
            movingDirection = Vector3.up;
        }
        else if (gameObject.transform.position.y > upperPosition)
        {
            movingDirection = Vector3.down;
        }
     
        
        if (dist< standRange)
        {
            isAlive = false;
        }

        if (!isAlive)
        {
            transform.gameObject.SetActive(false);
        }
	}

    void OnCollisionEnter(Collision playerCollision)
    {
        if (playerCollision.gameObject.tag == "Player")
        {
            isAlive = false;
        }
    }
}

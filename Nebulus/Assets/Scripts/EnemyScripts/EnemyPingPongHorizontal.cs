using UnityEngine;
using System.Collections;

public class EnemyPingPongHorizontal : MonoBehaviour {

    public GameObject player;
    float speed = 5;
    float attackRange=4f;
    float standRange = 0.1f;
    bool isAlive=true;
    public float upperPosition;
    public float lowerPosition;
    private Vector3 movingDirection = Vector3.up;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
       

        float dist = Vector3.Distance(transform.position, player.transform.position);
        float distY = transform.position.z-player.transform.position.z;
        float step = speed * Time.deltaTime;
        
        Debug.Log(distY);

        if (dist < attackRange && distY<0f)
        {
            transform.LookAt(player.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
            gameObject.transform.Translate(movingDirection * Time.smoothDeltaTime * speed);

            if (gameObject.transform.position.y < lowerPosition)
            {
                movingDirection = Vector3.up;
            }

            else if (gameObject.transform.position.y > upperPosition)
            {
                movingDirection = Vector3.down;
            }
        }
        if (dist< standRange)
        {
            isAlive = false;
        }
        if (!isAlive)
        {
            transform.gameObject.SetActive(false);
        }
        //TODO:
        //PingPong movement update
	}

    void OnCollisionEnter(Collision playerCollision)
    {
        if (playerCollision.gameObject.tag == "Player")
        {
            playerCollision.gameObject.transform.position += new Vector3(-3f, -1f * Time.deltaTime, 2f);
            isAlive = false;
        }
    }
}

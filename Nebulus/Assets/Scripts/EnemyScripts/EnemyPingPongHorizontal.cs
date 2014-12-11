using UnityEngine;
using System.Collections;

public class EnemyPingPongHorizontal : MonoBehaviour {

    private Vector3 movingDirection = Vector3.up;
    private bool isAlive = true;
    public GameObject player;
    public float speed;
    public float attackRange;
    public float killRange;
    public float upperPosition;
    public float lowerPosition;

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

        gameObject.transform.Translate(movingDirection * Time.smoothDeltaTime * speed);

        if (gameObject.transform.position.y < lowerPosition)
        {
            movingDirection = Vector3.up;
        }
        else if (gameObject.transform.position.y > upperPosition)
        {
            movingDirection = Vector3.down;
        }

        if (dist< killRange)
        {
            isAlive = false;
        }

        if (!isAlive)
        {
            Destroy(gameObject);
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

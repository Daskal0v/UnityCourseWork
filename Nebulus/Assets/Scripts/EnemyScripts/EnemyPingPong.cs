using UnityEngine;
using System.Collections;

public class EnemyPingPong : MonoBehaviour {

    private Vector3 movingDirection = Vector3.up;
    public float upperPosition;
    public float lowerPosition;
    public float speed;

	// Use this for initialization
    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(movingDirection * Time.smoothDeltaTime*speed);

        if (gameObject.transform.position.y < lowerPosition)
        {
            movingDirection = Vector3.up;
        }
        else if (gameObject.transform.position.y > upperPosition)
        {
            movingDirection = Vector3.down;
        }
	}
}

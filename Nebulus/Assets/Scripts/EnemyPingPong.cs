using UnityEngine;
using System.Collections;

public class EnemyPingPong : MonoBehaviour {

    private Vector3 MovingDirection = Vector3.up;
    public float upperPosition;
    public float lowerPosition;
    private float speed = 2;

	// Use this for initialization
    void Start()
    {
    }
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(MovingDirection * Time.smoothDeltaTime*speed);
        if (gameObject.transform.position.y < lowerPosition)
        {
            MovingDirection = Vector3.up;
        }

        else if (gameObject.transform.position.y > upperPosition)
        {
            MovingDirection = Vector3.down;
        }
	}
}

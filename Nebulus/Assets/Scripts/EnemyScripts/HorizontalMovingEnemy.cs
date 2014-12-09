using UnityEngine;
using System.Collections;

public class HorizontalMovingEnemy : MonoBehaviour {

    //private Vector3 movingDirection = Vector3.right;
    //public float upperPosition;
    //public float lowerPosition;
    //public float speed = 2;

    //private float radiusA = 5.5f;
    //private float radiusB = 5.5f;
    //private float angle;
    //Vector3 center;
    //float translation;

    //// Use this for initialization
    //void Start () {
	
    //}
	
    //// Update is called once per frame
    //void Update () {
    //    center = new Vector3(0f, transform.position.y, 0f);

    //    //.RotateAround(Vector3.zero, Vector3.up, rotationSpeed * Time.deltaTime);
    //    gameObject.transform.Translate(movingDirection * Time.smoothDeltaTime * speed);
    //    if (gameObject.transform.position.y < lowerPosition)
    //    {
    //        movingDirection = Vector3.up;
    //    }

    //    else if (gameObject.transform.position.y > upperPosition)
    //    {
    //        movingDirection = Vector3.down;
    //    }
    //}

    public float radius = 10f;
    public float speed = 1f;
    public bool offsetIsCenter = true;
    public Vector3 offset;
    float sign = 1;

    void Start()
    {
        if (offsetIsCenter)
        {
            offset = transform.position;
        }
    }

    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, 10 * Time.deltaTime * sign);
    
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
        sign = -1;

    }
}

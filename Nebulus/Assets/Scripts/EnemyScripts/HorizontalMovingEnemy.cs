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
    private Vector3 firstPoint = new Vector3(4.65f, 10.09f, 3.38f);
    private Vector3 secondPoint = new Vector3(0, 10.09f, 5.75f);

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
        float dist1 = Vector3.Distance(this.transform.position, firstPoint);
        float dist2 = Vector3.Distance(this.transform.position, secondPoint);
                    
        //Debug.Log(string.Format("Distance between player and {0} is {1}", portal.name, dist));
        if (dist1 <= 0.4)
        {
            sign = 1;
        }
        else if (dist2 <= 0.4)
        {
            sign = -1;
        }

        transform.position = new Vector3(
                    (radius * Mathf.Cos(Time.time * sign * speed)) + offset.x,
                    offset.y,
                    (radius * Mathf.Sin(Time.time * sign * speed)) + offset.z);
        

        //transform.Translate(direction * Time.deltaTime * 2, Space.World);
            //this.transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, elevatorInitialPosition, transform.position.z), 2 * Time.deltaTime);      
    }
}

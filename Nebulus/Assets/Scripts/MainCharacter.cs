using UnityEngine;
using System.Collections;

public class MainCharacter : MonoBehaviour {
    //position on the circle in rad
    public float mPosition;
    //rotation radius
    public float mRadius;
    public Vector3 center = new Vector3 (0, 0, 0);
    public float usabilityDistance;

    private Vector3 m_InitialPosition;
    bool isJumpReady;

    // Use this for initialization
	void Start ()
    {
        //rotation center
        isJumpReady = true;
	}
	
	// Update is called once per frame
	void Update ()
    {

        m_InitialPosition = new Vector3(0, transform.position.y, 0);

        //Movement around tower logic
        float hor = Input.GetAxis("Horizontal");
        if (hor != 0.0f)
        {
            mPosition += Time.deltaTime * - hor; // 1.0f is the rotation speed in radians per sec.
            var pos = new Vector3(Mathf.Sin(mPosition), 0, Mathf.Cos(mPosition));
            //Debug.Log(string.Format("Position is: {0}", pos));
            //Debug.Log(string.Format("mPos is: {0}", mPosition));
            transform.position = m_InitialPosition + pos * mRadius;
            transform.LookAt(new Vector3(0, transform.position.y, 0));
            //Debug.Log(string.Format("Horizontal movement: {0}", hor.ToString()));
        }

        //Jump logic
        float jump = Input.GetAxis("Jump");
        if (jump != 0.0f && isJumpReady)
        {
            //Debug.Log("Jump");
            isJumpReady = false;
            var pos = new Vector3(0, 5, 0);
            rigidbody.velocity = pos;
            //transform.position += pos;
        }

        //Interact
        bool isInteracticng = Input.GetKeyDown(KeyCode.DownArrow);
        if(isInteracticng)
        {
            //Debug.Log("Using");
            var usableObjects = GameObject.FindGameObjectsWithTag("usable");
            GameObject closestUsable = null;
            var distance = float.MaxValue;
            foreach (GameObject usable in usableObjects)
            {
                float dist = Vector3.Distance(usable.transform.position, transform.position);
                Debug.Log(string.Format("Distance between player and {0} is {1}", usable.name, dist));
                if (dist < usabilityDistance && dist < distance)
                {
                    closestUsable = usable;
                    distance = dist;
                }
            }
            if (closestUsable != null)
            {
                closestUsable.BroadcastMessage("Activate");
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        //Debug.Log("Jump ready");
        isJumpReady = true;
    }

    void Transport(Vector3 newPosition)
    {
        transform.position = newPosition; 
        transform.LookAt(new Vector3(0, transform.position.y, 0));
        mPosition = Mathf.Atan2(transform.position.x, transform.position.z);
    }
}
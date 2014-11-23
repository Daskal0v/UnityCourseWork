using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
    GameObject[] Holes;
    public Transform Decore;
    public float jumpForce = 100;
    public float MoveSpeed = 1f;
    float totalRotate = 0;
    Vector3 posit , scale;
    bool ActivateElevator = false;
    bool ActiveHole = true;
    bool isLive = true;
    bool isGrounded = false;
    bool isJump = false;
    // Use this for initialization
	void Start () {
        Holes = GameObject.FindGameObjectsWithTag("Hole");
	}
	
	// Update is called once per frame
	void Update () {
        
        //Check character live;
        if (!isLive) {
            transform.GetChild(0).active = false;
            transform.GetChild(1).active = true;
        }
        else
        {
            //Character navigation
            if (Input.GetKey(KeyCode.LeftArrow)) 
            {
                //Left move of character
                Decore.Rotate(0, Time.deltaTime*-10, 0);
                transform.eulerAngles = new Vector2(0, 0);
                
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //Right move of character
                Decore.Rotate(0, Time.deltaTime*10, 0);
                transform.eulerAngles = new Vector2(0, 180);
                
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                //Activate elevators
                ActivateElevator = true;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
               //Character jump
                isJump = true;
            }
        }
	}
    void FixedUpdate() {
        if (isJump)
        {
            transform.rigidbody.velocity = new Vector3(0, jumpForce, 0);
        }
        
    }
    void OnCollisionEnter(Collision thecollision) {
        if (thecollision.gameObject.name == "Water")
        {
            isLive = false;
        }
    }
    void OnCollisionStay(Collision thecollision)
    {
        //Set Elevators new property
        if (thecollision.gameObject.name == "Upward")
        {
            if (ActivateElevator)
            {
                if (thecollision.gameObject.transform.localScale.y < 2) { 
                    thecollision.gameObject.transform.position += transform.up * Time.deltaTime * 0.5f;
                    thecollision.gameObject.transform.localScale += transform.up * Time.deltaTime * 0.9f;
                }
            }
        }
    }
    void OnCollisionExit(Collision thecollision)
    {
        //Deactivate permition of elevators
        if (thecollision.gameObject.name == "Upward")
        {
            ActivateElevator = false;
            UnityEditor.PrefabUtility.ResetToPrefabState(thecollision.gameObject);
        }
    }
    void OnTriggerEnter(Collider colide) {
        if (colide.gameObject.name == "Enemy")
        {
            transform.FindChild("FrogRight").active = false;
            transform.FindChild("FrogDied").active = true;
            isLive = false;
        }

        if (colide.gameObject.name == "Hole")
        {
            if (ActiveHole)
            {
                //Deactivate Holes
                ActiveHole = false;
                Decore.Rotate(0,Mathf.Clamp(Time.time,Decore.position.x,180), 0);
            }
        }
        if (colide.gameObject.name == "Exit")
        {
            //YOU WINN

        }
    }
    void OnTriggerExit(Collider colide)
    {
        if (colide.gameObject.name == "Hole")
        {
            ActiveHole = true;
        }
    }
}

using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
    
    public Transform Decore;
    
    public float JumpForce = 100;
    public float MoveSpeed = 1f;

    float totalRotate = 0;
    bool ElevatorUp = false;
    bool ActivateDoor = false;
    bool isLive = true;
    bool isJumpEnable = true;
    bool isWin = false;
    
    // Use this for initialization
	void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {

        
        //Check character live;
        if (!isLive) {
            //transform.GetChild(0).active = false;
            //transform.GetChild(1).active = true;
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
                ElevatorUp = false;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                ElevatorUp = true;
                ActivateDoor = true;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
               //Character jump
                if (isJumpEnable && Input.GetAxis("Jump") != 0.0f)
                {
                    isJumpEnable = false;
                    transform.rigidbody.velocity = new Vector3(0, JumpForce, 0);
                }
                
            }
        }
	}

    void OnCollisionEnter(Collision thecollision) {
        //enable jump of the character
        isJumpEnable = true;
        
        //Detect collision with water
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
            if (ElevatorUp)
            {
                if (thecollision.gameObject.transform.localScale.y < 2) { 
                    thecollision.gameObject.transform.position += transform.up * Time.deltaTime * 0.5f;
                    thecollision.gameObject.transform.localScale += transform.up * Time.deltaTime * 0.9f;
                }
            }
            else
            {
                if (thecollision.gameObject.transform.localScale.y > 0.1f)
                {
                    thecollision.gameObject.transform.position -= transform.up * Time.deltaTime * 0.5f;
                    thecollision.gameObject.transform.localScale -= transform.up * Time.deltaTime * 0.9f;
                }
            }
        }
    }
    void OnTriggerEnter(Collider colide) {
        if (colide.gameObject.name == "Enemy")
        {
            //transform.FindChild("FrogRight").active = false;
            //transform.FindChild("FrogDied").active = true;
            isLive = false;
        }

        if (colide.gameObject.name == "CastleDoor")
        {
            if (colide.gameObject.tag != "Door")
            {
                //Debug.Log("Not door");
                if (ActivateDoor)
                {
                    //Debug.Log("ActiveDoor");
                    Decore.Rotate(Vector3.up, 180);
                    ActivateDoor = false;
                }
            }
            else {
                transform.position = new Vector3(transform.position.x,21.2f, -4.3f);
                isWin = true;
            }
            
        }
        
    }
    void OnGUI(){
        //Win message 
        if (isWin)
        {
            GUI.Box(new Rect(Screen.width / 2 -25, Screen.height / 2 - 10, 25, 10), "You Win");
            
        }
    }
}

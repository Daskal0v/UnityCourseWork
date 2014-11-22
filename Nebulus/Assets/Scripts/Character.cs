using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
    GameObject[] Holes;
   
    float totalRotate = 0;
    public Transform Decore;
    Vector3 posit , scale;
    public float MoveSpeed = 1f;
    bool ActivateElevator = false;
    bool ActiveHole = true;
    bool Live = true;
	// Use this for initialization
	void Start () {
        Holes = GameObject.FindGameObjectsWithTag("Hole");
	}
	
	// Update is called once per frame
	void Update () {
       // Text.guiText.text = "Game over";
        //Debug.Log(Text.ToString());
        if (!Live) {
            transform.GetChild(0).active = false;
            transform.GetChild(1).active = true;
            
        }
        //Hero die
        if(transform.position.y< -2)
        {
            Live = false;
        }
        
        
        //Check character live;
        if (Live)
        {
            //Character navigation
            if (Input.GetKey(KeyCode.LeftArrow)) 
            {
                //Left move of character
                
                Decore.Rotate(0, Time.deltaTime*-10, 0);
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    transform.eulerAngles = new Vector2(0, 0);
                }
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //Right move of character
                
                Decore.Rotate(0, Time.deltaTime*10, 0);
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    transform.eulerAngles = new Vector2(0, 180);
                }
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                //Activate elevators
                ActivateElevator = true;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //Character jump
                transform.position = transform.up + new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            }
        }
	}
    void OnCollisionEnter(Collision thecollision) {
        if (thecollision.gameObject.name == "Water")
        {
            Live = false;
        }
    }
    void OnCollisionStay(Collision thecollision)
    {
        //Set Elevators new property
        if (thecollision.gameObject.name == "Upward")
        {
            if (ActivateElevator)
            {
                //scale = thecollision.gameObject.transform.localScale;
                //posit = thecollision.gameObject.transform.position;
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
           // Debug.Log("sada");
            ActivateElevator = false;

            UnityEditor.PrefabUtility.ResetToPrefabState(thecollision.gameObject);
        }
    }
    void OnTriggerEnter(Collider colide) {
        if (colide.gameObject.name == "Enemy")
        {
            transform.FindChild("FrogRight").active = false;
            transform.FindChild("FrogDied").active = true;
            Live = false;
        }

        if (colide.gameObject.name == "Hole")
        {
            if (ActiveHole)
            {
                //Deactivate Holes
                ActiveHole = false;
                Debug.Log("HOLE Enter");
                //Deactivate hero
                //transform.gameObject.SetActive(false);

                
                //Decore.Rotate(0, Decore.position.y + 157, 0);
                Decore.eulerAngles = new Vector3(0,Mathf.Round(Decore.position.y + 170),0);
                //Decore.position = new Vector3(0, Mathf.Clamp());
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

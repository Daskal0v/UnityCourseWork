using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour
{
    bool elevateUp = false;
    bool elevateDown = false;
	// Update is called once per frame
    void OnCollisionEnter(Collision theCollision)
    {
            if (theCollision.contacts[0].normal.y > 0)
            {
                transform.BroadcastMessage("EnableJump");
            }
        
        
        
    }
    void OnCollisionStay(Collision theCollision)
    {
        if (theCollision.gameObject.name == "Upward")
        {
            transform.BroadcastMessage("ElevateEnable");
            if (elevateUp) 
            {
                if (theCollision.gameObject.transform.localScale.y < 2)
                {
                    //Debug.Log(theCollision.gameObject.transform.position.ToString());
                    theCollision.gameObject.transform.position += transform.up * Time.deltaTime * 0.5f;
                    theCollision.gameObject.transform.localScale += transform.up * Time.deltaTime * 0.9f;
                }
                else
                {
                    elevateUp = false;
                    transform.BroadcastMessage("ElevateDisable");
                }
            }
            else if(elevateDown)
            {
                if (theCollision.gameObject.transform.localScale.y > 0.1f)
                {
                    theCollision.gameObject.transform.position -= transform.up * Time.deltaTime * 0.5f;
                    theCollision.gameObject.transform.localScale -= transform.up * Time.deltaTime * 0.9f;
                }
                else
                {
                    transform.BroadcastMessage("ElevateDisable");
                    elevateDown = false;
                }
            }
            
        }
    }
    void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.name == "Upward")
        {
            transform.BroadcastMessage("ElevateDisable");
        }
    }
    void ElevatorUp()
    {
        elevateUp = true;
    }
    void ElvateDown()
    {
        elevateDown = true;
    }
}

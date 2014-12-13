using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

    public float elevateToHeight;
    public bool returnToInitialPosition;
    public float secondsToReturnInInitialPosition;

    GameObject player;
    private bool activateUp = false;
    private bool activateDown = false;
    private float elevatorInitialPosition;
    private float timer = 0.0f;

    void Start ()
    {
        player = GameObject.Find("Character");
        elevatorInitialPosition = this.transform.position.y;
        //Debug.Log(elevatorInitialPosition.ToString());
        //Debug.Log(player.ToString());
    }

	// Update is called once per frame
	void Update () 
    {
        
        if (activateUp)
        {
            player.transform.parent = transform;
            this.transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, elevateToHeight, transform.position.z), 3*Time.deltaTime);
            //player.transform.position = Vector3.Lerp(player.transform.position, new Vector3(player.transform.position.x, elevateToHeight + 0.9f, player.transform.position.z), 2 * Time.deltaTime);

            if (transform.position.y == elevateToHeight)
            {
                activateUp = false;
                player.transform.parent = null;
                //this.transform.DetachChildren();
            }
        }

        else if (activateDown)
        {
            player.transform.parent = transform;
            this.transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, elevatorInitialPosition, transform.position.z), 2 * Time.deltaTime);
            //player.transform.position = Vector3.Lerp(player.transform.position, new Vector3(player.transform.position.x, elevatorInitialPosition + 0.9f, player.transform.position.z), 2 * Time.deltaTime);

            if (transform.position.y == elevatorInitialPosition)
            {
                activateDown = false;
                //this.transform.DetachChildren();
            }
        }
        if ((this.transform.position.y >= (elevateToHeight - 0.6f)) && returnToInitialPosition)
        {
            timer += Time.deltaTime;

            //Debug.Log(timer.ToString());
            if (timer >= secondsToReturnInInitialPosition)
            {
                this.transform.DetachChildren();
                this.transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, elevatorInitialPosition, transform.position.z), 20);
                timer = 0.0f;
                activateUp = false;
                activateDown = false;
            }
        }
        
	}

    void OnCollisionEnter(Collision collision)
    {
            //Debug.Log("OnCollisionEnter");

            if (collision.gameObject.CompareTag("Player"))
            {
                player.gameObject.BroadcastMessage("ReadyToElevate", this.gameObject);
            }
        
    }

    void OnCollisionExit(Collision collision)
    {
        //Debug.Log("OnCollisionExit");
        //this does not work, don't know why
        
        player.gameObject.BroadcastMessage("ExitElevator");
    }

    public void ActivateUP()
    {
       // Debug.Log("ElevateUP!!!");

        activateUp = true;
        activateDown = false;
    }

    public void ActivateDown()
    {
        //Debug.Log("ElevateDown!!!");

        activateDown = true;
        activateUp = false;
    }
}

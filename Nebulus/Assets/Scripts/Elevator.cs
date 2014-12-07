using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

    public float elevateToHeight;
    private float playerPosition;
    public bool returnToInitialPosition;
    public bool isInitiallyElevated;
    GameObject player;
    private bool activateUp = false;
    private bool activateDown = false;
    private float elevatorInitialPosition;

    void Start ()
    {
        player = GameObject.Find("Character");
        elevatorInitialPosition = this.transform.position.y;
        Debug.Log(elevatorInitialPosition.ToString());
        Debug.Log(player.ToString());
    }

	// Update is called once per frame
	void Update () 
    {
        
        if (activateUp)
        {
            this.transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, elevateToHeight, transform.position.z), 2*Time.deltaTime);
            player.transform.position = Vector3.Lerp(player.transform.position, new Vector3(player.transform.position.x, elevateToHeight + 0.9f, player.transform.position.z), 2 * Time.deltaTime);

            if (transform.position.y == elevateToHeight)
            {
                activateUp = false;
                playerPosition = 0;
            }
        }

        else if (activateDown)
        {
            this.transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, elevatorInitialPosition, transform.position.z), 2 * Time.deltaTime);
            player.transform.position = Vector3.Lerp(player.transform.position, new Vector3(player.transform.position.x, elevatorInitialPosition + 0.9f, player.transform.position.z), 2 * Time.deltaTime);

            if (transform.position.y == elevatorInitialPosition)
            {
                activateDown = false;
                playerPosition = 0;
            }
        }
	}

    void OnCollisionStay(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
        
        if (collision.gameObject.CompareTag("Player"))
        {
            player.gameObject.BroadcastMessage("ReadyToElevate",this.gameObject);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("OnCollisionExit");

        player.gameObject.BroadcastMessage("ExitElevator");
    }

    public void ActivateUP()
    {
        Debug.Log("ElevateUP!!!");

        activateUp = true;
    }

    public void ActivateDown()
    {
        Debug.Log("ElevateDown!!!");

        activateDown = true;
        activateUp = false;
    }
}

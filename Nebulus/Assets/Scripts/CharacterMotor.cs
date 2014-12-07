using UnityEngine;
using System.Collections;

public class CharacterMotor : MonoBehaviour
{

    public Animator controller;
    public Transform parent;
    public int rotationSpeed = 10;
    public float portalReach;
    int[] stateHashes = new int[6];
    bool isJumpEnable = true;
    bool isElevateEnable = false;
    bool readyToElevate = false;
    GameObject currentElevator;
    // Initialization
    void Start()
    {

        stateHashes[0] = Animator.StringToHash("WalkLeft");
        stateHashes[1] = Animator.StringToHash("Jump");
        stateHashes[2] = Animator.StringToHash("WalkRight");
        stateHashes[3] = Animator.StringToHash("EnterDoor");
        stateHashes[4] = Animator.StringToHash("Fall");
        stateHashes[5] = Animator.StringToHash("ExitDoor");
        controller = gameObject.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {



        // Walk left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //controller.SetBool(stateHashes[0], true);
            controller.SetBool("WalkLeft", true);
            parent.transform.RotateAround(Vector3.zero, Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // Stop walking left
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            //controller.SetBool(stateHashes[0], false);
            controller.SetBool("WalkLeft", false);
        }

        // Walk right
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //controller.SetBool(stateHashes[2], true);
            controller.SetBool("WalkRight", true);
            parent.transform.RotateAround(Vector3.zero, Vector3.up, rotationSpeed * Time.deltaTime * -1);
        }

        // Stop walking right
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            //controller.SetBool(stateHashes[2], false);
            controller.SetBool("WalkRight", false);
        }

        // Jump 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //if ((controller.GetBool(stateHashes[0]) == true) || (controller.GetBool(stateHashes[2]) == true))
            if (controller.GetBool("WalkLeft") == true || controller.GetBool("WalkRight") == true)
            {
                //controller.SetBool(stateHashes[0], false);
                //controller.SetBool(stateHashes[2], false);
                //controller.SetBool(stateHashes[1], true);
                controller.SetBool("WalkLeft", false);
                controller.SetBool("WalkRight", false);
            }
            float jump = Input.GetAxis("Jump");
            if (jump != 0.0f && isJumpEnable)
            {
                isJumpEnable = false;
                controller.SetBool("Jump", true);
                var pos = new Vector3(0, 5, 0);
                parent.rigidbody.velocity = pos;
            }
        }

        // Stop jumping 
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            //controller.SetBool(stateHashes[1], false);
            //controller.SetBool("Jump", false);
        }

        // In the door
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            //TODO: Future bug where pogo will not enter a door if standing on an elevator.
            if (!isElevateEnable)
            {
                GameObject[] allPortals = GameObject.FindGameObjectsWithTag("Portal");
                var distance = float.MaxValue;
                GameObject closestPortal = null;
                foreach (var portal in allPortals)
                {
                    float dist = Vector3.Distance(portal.transform.position, parent.transform.position);
                    //Debug.Log(string.Format("Distance between player and {0} is {1}", portal.name, dist));
                    if (dist < portalReach && dist < distance)
                    {
                        closestPortal = portal;
                        distance = dist;
                    }
                }
                if (closestPortal != null)
                {
                    //controller.SetBool(stateHashes[3], true);
                    controller.SetBool("EnterDoor", true);
                    closestPortal.BroadcastMessage("Activate");
                }
            }
            if (readyToElevate)
            {
                Debug.Log("ActivateUP" + readyToElevate);
                if (currentElevator != null)
                {
                    Debug.Log("ActivateUP");
                    currentElevator.gameObject.BroadcastMessage("ActivateUP");
                }
            }
        }

        // Out of the door
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            //controller.SetBool(stateHashes[3], false);
            controller.SetBool("EnterDoor", false);
        }

         // Fall
        else if (Input.GetKeyDown(KeyCode.F))
        {
            //controller.SetBool(stateHashes[4], true);
            controller.SetBool("Fall", true);
        }

        // Stop falling
        else if (Input.GetKeyUp(KeyCode.F))
        {
            //controller.SetBool(stateHashes[4], false);
            controller.SetBool("Fall", false);
        }

        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Test");
            if (readyToElevate)
            {
                if (currentElevator != null)
                {
                    Debug.Log("ActivateDown");
                    currentElevator.gameObject.BroadcastMessage("ActivateDown");
                }
            }
        }
    }

    /// <summary>
    /// This method needs to rotate the camera smoothly around the tower.
    /// </summary>
    /// <param name="newPosition">The position where the character will spawn.</param>
    void Transport(Vector3 newPosition)
    {
        parent.transform.position = newPosition;
        //parent.TransformPoint(newPosition);
        parent.transform.LookAt(new Vector3(0, transform.position.y, 0));
    }

    void ReadyToElevate(GameObject elevator)
    {
        Debug.Log("ReadyToElevate");
        readyToElevate = true;
        Debug.Log(readyToElevate);
        currentElevator = elevator;
    }

    void ExitElevator()
    {
        Debug.Log("ExitElevator");
        readyToElevate = false;
    }

    void EnableJump()
    {
        Debug.Log("Jump enabled!");
        isJumpEnable = true;
        controller.SetBool("Jump", false);
    }
    void ElevateEnable()
    {
        isElevateEnable = true;
    }
    void ElevateDisable()
    {
        isElevateEnable = false;
    }
}

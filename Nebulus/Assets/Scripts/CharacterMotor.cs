using UnityEngine;
using System.Collections;

public class CharacterMotor : MonoBehaviour {

    public Animator controller;
    public Transform parent;
    public int rotationSpeed = 10;
    int[] stateHashes = new int[5];
    bool isJumpEnable = true;
    bool isElevateEnable = false;

    // Initialization
    void Start()
    {

        stateHashes[0] = Animator.StringToHash("WalkLeft");
        stateHashes[1] = Animator.StringToHash("Jump");
        stateHashes[2] = Animator.StringToHash("WalkRight");
        stateHashes[3] = Animator.StringToHash("Door");
        stateHashes[4] = Animator.StringToHash("Fall");
        controller = gameObject.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        
        

        // Walk left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            controller.SetBool(stateHashes[0], true);
            parent.transform.RotateAround(Vector3.zero, Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // Stop walking left
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            controller.SetBool(stateHashes[0], false);
        }

        // Walk right
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            controller.SetBool(stateHashes[2], true);
            parent.transform.RotateAround(Vector3.zero, Vector3.up, rotationSpeed * Time.deltaTime * -1);
        }

        // Stop walking right
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            controller.SetBool(stateHashes[2], false);
        }

        // Jump 
        else if (Input.GetKeyDown(KeyCode.Space))
        {
         
            if ((controller.GetBool(stateHashes[0]) == true) || (controller.GetBool(stateHashes[2]) == true))
            {
                controller.SetBool(stateHashes[0], false);
                controller.SetBool(stateHashes[2], false);
                controller.SetBool(stateHashes[1], true);
            }
            float jump = Input.GetAxis("Jump");
            if (jump != 0.0f && isJumpEnable)
            {
                isJumpEnable = false;
                var pos = new Vector3(0, 5, 0);
                parent.rigidbody.velocity = pos;
            }
        }

        // Stop jumping 
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            controller.SetBool(stateHashes[1], false);
        }

        // In the door
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!isElevateEnable)
            {
                controller.SetBool(stateHashes[3], true);
            }
            else
            {
                parent.BroadcastMessage("ElevatorUp");
            }
            
        }

        // Out of the door
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            controller.SetBool(stateHashes[3], false);
        }

         // Fall
        else if (Input.GetKeyDown(KeyCode.F))
        {
            controller.SetBool(stateHashes[4], true);
        }

        // Stop falling
        else if (Input.GetKeyUp(KeyCode.F))
        {
            controller.SetBool(stateHashes[4], false);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            parent.BroadcastMessage("ElvateDown");
        }
    }
    void EnableJump()
    {
        isJumpEnable = true;

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

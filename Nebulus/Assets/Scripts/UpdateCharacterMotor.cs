using UnityEngine;
using System.Collections;

public class UpdateCharacterMotor : MonoBehaviour {

    public Animator animController;
    public Transform ancestor;
    public int rotateSpeed = 10;
    public int[] states = new int[5];
    bool isJumping = true;
    bool isElevatorOn = false;

	// Use this for initialization
	void Start () {
        states[0] = Animator.StringToHash("WalkLeft");
        states[1] = Animator.StringToHash("Jump");
        states[2] = Animator.StringToHash("WalkRight");
        states[3] = Animator.StringToHash("Door");
        states[4] = Animator.StringToHash("Fall");
        animController = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

	    // Walk left
        if (CheckIfWalkingLeft() == true && IsSpacePushed() == false)
        {
            animController.SetBool(states[0], true);
            ancestor.transform.RotateAround(Vector3.zero, Vector3.up, rotateSpeed * Time.deltaTime);
        }

        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {

            animController.SetBool(states[0], false);
        }

        // Walk right
        if (CheckIfWalkingRight() == true && IsSpacePushed() == false)
        {
            animController.SetBool(states[2], true);
            ancestor.transform.RotateAround(Vector3.zero, Vector3.up, rotateSpeed * Time.deltaTime * -1);

        }

        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {

            animController.SetBool(states[2], false);
        }

        // Jump
        if ((CheckIfWalkingRight() == true || CheckIfWalkingLeft() == true) && IsSpacePushed() == true)
        {
            float jump = Input.GetAxis("Jump");
            if (jump != 0.0f && isJumping)
            {
                isJumping = false;
                var pos = new Vector3(0, 5, 0);
                ancestor.rigidbody.velocity = pos;
                if ((animController.GetBool(states[0]) == true) || (animController.GetBool(states[2]) == true))
                {
                    animController.SetBool(states[0], false);
                    animController.SetBool(states[2], false);
                    animController.SetBool(states[1], true);
                }
            }

            else if (Input.GetKeyUp(KeyCode.Space))
            {
                animController.SetBool(states[1], false);
            }
        }

        else if (Input.GetKeyUp(KeyCode.Space))
        {
            animController.SetBool(states[1], false);
        }


        // In the door
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!isElevatorOn)
            {
                animController.SetBool(states[3], true);
            }
            else
            {
                ancestor.BroadcastMessage("ElevatorUp");
            }
        }

        // Out of the door
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            animController.SetBool(states[3], false);
        }

        // Fall
        else if (Input.GetKeyDown(KeyCode.F))
        {
            animController.SetBool(states[4], true);
        }

        // Stop falling
        else if (Input.GetKeyUp(KeyCode.F))
        {
            animController.SetBool(states[4], false);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            ancestor.BroadcastMessage("ElvateDown");
        }
    }

     internal static bool IsSpacePushed()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            return true;
        }
        return false;
    }

    internal static bool CheckIfWalkingLeft()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            return true;
        }
        return false;
    }

    internal static bool CheckIfWalkingRight()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            return true;
        }
        return false;
    }

    void EnableJump()
    {
        isJumping = true;
    }

    void ElevateEnable()
    {
        isElevatorOn = true;
    }
    void ElevateDisable()
    {
        isElevatorOn = false;
    }
}


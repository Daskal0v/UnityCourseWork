using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

    public Animator controller;
    int[] stateHashes = new int[5];

	// Use this for initialization
	void Start () {
        stateHashes[0] = Animator.StringToHash("WalkLeft");
        stateHashes[1] = Animator.StringToHash("Jump");
        stateHashes[2] = Animator.StringToHash("WalkRight");
        stateHashes[3] = Animator.StringToHash("Door");
        stateHashes[4] = Animator.StringToHash("Fall");
        controller = gameObject.GetComponent<Animator>();
	}
	

	// Update is called once per frame
	void Update () {

        // Walk left
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            controller.SetBool(stateHashes[0], true);
        }

        // Stop walking left
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            controller.SetBool(stateHashes[0], false);
        }

        // Walk right
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            controller.SetBool(stateHashes[2], true);
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
        }

        // Stop jumping 
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            controller.SetBool(stateHashes[1], false);
        }

        // In the door
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            controller.SetBool(stateHashes[3], true);
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
	}
}

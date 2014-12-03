using UnityEngine;
using System.Collections;

public class CharacterMotor : MonoBehaviour {

    public Animator controller;
    public Camera camera;
    public Transform parent;
    public int rotationSpeed = 10;
    int[] stateHashes = new int[5];
   

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
            camera.transform.RotateAround(Vector3.zero, Vector3.up, rotationSpeed * Time.deltaTime);
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
            camera.transform.RotateAround(Vector3.zero, Vector3.up, rotationSpeed * Time.deltaTime * -1 );
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

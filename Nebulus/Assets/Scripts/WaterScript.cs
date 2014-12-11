using UnityEngine;
using System.Collections;

public class WaterScript : MonoBehaviour
{
    //public Animator control;
    public GameObject initialPlatform;
    Vector3 initialPositionCharacter;
    Vector3 initialRotationOfCharacter;
    GameObject player;
    int lives;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //control = player.GetComponent<Animator>();
        initialPositionCharacter = player.transform.position;
        initialRotationOfCharacter = player.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            lives = PlayerPrefs.GetInt("Lives") - 1;
            PlayerPrefs.SetInt("Lives", lives);
            PlayerPrefs.Save();
            //This code is just for level 2 where 'InitiateLevel' script is used
            if (initialPlatform != null)
	        {
                var displ = new Vector3(0f, 3.87f, 0f);
                collision.gameObject.transform.position = initialPlatform.transform.position + displ;
                collision.gameObject.transform.LookAt(new Vector3(0f, collision.gameObject.transform.position.y, 0f));
	        }
            else
	        {
                collision.gameObject.transform.position = initialPositionCharacter;
                collision.gameObject.transform.localRotation = Quaternion.Euler(initialRotationOfCharacter);
                //control.SetBool("Fall", false);
	        }
        }
    }
}
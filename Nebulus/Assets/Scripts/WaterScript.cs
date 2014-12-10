using UnityEngine;
using System.Collections;

public class WaterScript : MonoBehaviour {
    //public Animator control;
    Vector3 initialPositionCharacter;
    Vector3 initialRotationOfCharacter;
    GameObject player;
    int lives;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        //control = player.GetComponent<Animator>();
        initialPositionCharacter = player.transform.position;
        initialRotationOfCharacter = player.transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            lives = PlayerPrefs.GetInt("Lives") - 1;
            PlayerPrefs.SetInt("Lives", lives);
            PlayerPrefs.Save();
            collision.gameObject.transform.position = initialPositionCharacter;
            collision.gameObject.transform.localRotation = Quaternion.Euler(initialRotationOfCharacter);
            //control.SetBool("Fall", false);
        }
    }
}

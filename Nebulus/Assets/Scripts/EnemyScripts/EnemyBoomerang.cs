using UnityEngine;
using System.Collections;

public class EnemyBoomerang : MonoBehaviour {
    public int howOften;
    public float speed;
    public bool lethal;
    //TODO: This needs to be abstract!
    public float screenWidth;

    float countDown;
    bool boomerangIsActive;
    Vector3 initialPosition;
    GameObject player;

	// Use this for initialization
	void Start () 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        resetBoomerang();
        initialPosition = transform.localPosition;
        Debug.Log(initialPosition);
	}
	
	// Update is called once per frame
	void Update () 
    {
        //Debug.Log(boomerangIsActive);
        if (countDown <= 0 && !boomerangIsActive)
        {
            //Debug.Log("Shout");
            boomerangIsActive = true;

            //0 will spawn boomerang from the left, 1 will spawn it from the right
            int direction = Random.Range(0, 2);
            Debug.Log(direction);
            if (direction == 0)
            {
                transform.position = new Vector3(screenWidth, player.transform.position.y, player.transform.position.z);
            }
            else if(direction == 1)
            {
                transform.position = new Vector3(-screenWidth, player.transform.position.y, player.transform.position.z);
            }
            else
            {
                throw new System.ArgumentOutOfRangeException("Either 0 or 1 is acceptable.");
            }
        }
        else if (countDown > 0)
        {
            Debug.Log(countDown);
            countDown -= Time.deltaTime;
        }

        if (boomerangIsActive)
        {
            //Debug.Log("Shout, boomerangIsActive");

            //if (direction == 0)
            {
                
            }
        }
	}

    /// <summary>
    /// After boomerang disapears from the screan it needs to be reset with a new timer and out of view.
    /// </summary>
    void resetBoomerang ()
    {
        Debug.Log("Shout reset boomerang");

        boomerangIsActive = false;
        float newTimer = Random.Range(1*howOften, 2*howOften);
        countDown = newTimer;
        transform.position = initialPosition;
    }
}
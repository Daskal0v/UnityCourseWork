using UnityEngine;
using System.Collections;

public class EnemyBoomerang : MonoBehaviour
{
    public int howOften;
    public float speed;
    public bool lethal;
    //TODO: This needs to be abstract!
    public float screenWidth;

    float countDown;
    bool boomerangIsActive;
    Vector3 initialPosition;
    GameObject player;
    int direction;
    float playerHeight;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        resetBoomerang();
        initialPosition = transform.position;
        Debug.Log(initialPosition);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(boomerangIsActive);
        if (countDown <= 0 && !boomerangIsActive)
        {
            //Debug.Log("Shout");
            boomerangIsActive = true;

            //0 will spawn boomerang from the left, 1 will spawn it from the right
            direction = Random.Range(0, 2);
            Debug.Log(direction);
            //NOTE: This can be done like that:
            //transform.localPosition = new Vector3(screenWidth * (-1 * direction), 0, 0);
            if (direction == 0)
            {
                transform.localPosition = new Vector3(screenWidth, 0, 0);
            }
            else if (direction == 1)
            {
                transform.localPosition = new Vector3(-screenWidth, 0, 0);
            }
            else
            {
                throw new System.ArgumentOutOfRangeException("Either 0 or 1 is acceptable.");
            }
            //Debug.Log(transform.position);

            StorePlayerHeight();
        }
        else if (countDown > 0)
        {
            //Debug.Log(countDown);
            countDown -= Time.deltaTime;
        }

        if (boomerangIsActive)
        {
            //Debug.Log("Shout, boomerangIsActive");
            float newHeight = playerHeight - player.transform.position.y;

            //NOTE: This can be done like that:
            //transform.localPosition = new Vector3(transform.localPosition.x - Time.deltaTime * speed * (-1 * direction), newHeight/2, 0);
            if (direction == 0)
            {
                transform.localPosition = new Vector3(transform.localPosition.x - Time.deltaTime * speed, (newHeight / 2) + 0.1f, 0);
                if (transform.localPosition.x <= -screenWidth)
                {
                    resetBoomerang();
                }
            }
            else if (direction == 1)
            {
                transform.localPosition = new Vector3(transform.localPosition.x + Time.deltaTime * speed, (newHeight / 2) + 0.1f, 0);
                if (transform.localPosition.x >= screenWidth)
                {
                    resetBoomerang();
                }
            }
        }
    }

    void OnCollisionEnter(Collision theCollision)
    {
        //Debug.Log("Shout Collision");
        //if (theCollision.gameObject.name != "Character")
        //{
            resetBoomerang();
        //}
    }


    void StorePlayerHeight()
    {
        playerHeight = player.transform.position.y;
    }

    /// <summary>
    /// After boomerang disapears from the screan it needs to be reset with a new timer and out of view.
    /// </summary>
    void resetBoomerang()
    {
        //Debug.Log("Shout reset boomerang");

        boomerangIsActive = false;
        float newTimer = Random.Range(1 * howOften, 2 * howOften);
        countDown = newTimer;
        transform.position = initialPosition;
        direction = -1;
    }
}
using UnityEngine;
using System.Collections;

public class Elevator : MonoBehaviour {

    public float elevateToHeight;
    float playerPosition;
    public bool returnToInitialPosition;
    public bool isInitiallyElevated;
    private float timer = 0.0f;
    GameObject player;
    public float timeToElevate;

    void Awake ()
    {
        player = GameObject.Find("Character");
    }

	// Use this for initialization
	void Start () 
    {
        //transform.LookAt(new Vector3(0, transform.position.y, 0));
	}
	
	// Update is called once per frame
	void Update () 
    {
	}

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
        
        if (collision.gameObject.CompareTag("Player"))
        {
            player.gameObject.BroadcastMessage("ReadyToElevate",this.gameObject);
        }
    }

    public void Activate()
    {
        
        Debug.Log("Elevate!!!");
        playerPosition = (player.transform.position.y - this.transform.position.y);
        while (timer < timeToElevate)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, elevateToHeight, transform.position.z), timer);
            player.transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, elevateToHeight + playerPosition, transform.position.z), timer);
            timer += Time.deltaTime;
        }
    }
}

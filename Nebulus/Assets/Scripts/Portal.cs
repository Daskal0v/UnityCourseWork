using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour 
{
    public GameObject exitPortal;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void Activate()
    {
        //Debug.Log("Transport!!!");
        GameObject player = GameObject.Find("Character");
        //We need to change this value if Pogo spawns to neer or far from a portal.
        float towerRadiusToPathRadius = 1.15f;
        Vector3 exitLocation = new Vector3(towerRadiusToPathRadius * exitPortal.transform.position.x, 1f * exitPortal.transform.position.y, towerRadiusToPathRadius * exitPortal.transform.position.z);
        player.gameObject.BroadcastMessage("Transport", exitLocation);
    }
}

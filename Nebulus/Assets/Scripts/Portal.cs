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
        Debug.Log("Transport!!!");
        GameObject player = GameObject.Find("Character");
        player.gameObject.BroadcastMessage("Transport", exitPortal.transform.position);
    }
}

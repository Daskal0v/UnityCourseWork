using UnityEngine;
using System.Collections;

public class BouncyEnemy : MonoBehaviour 
{
    
    bool isJumpReady = true;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        GameObject player = GameObject.Find("Character");
        //Debug.Log(player.name);
        float distance = Vector3.Distance(transform.position, player.transform.position);
        //Debug.Log(string.Format("Distance is: {0}", distance));
        if (distance < 2f)
        {
            float deltaH = player.transform.position.y - transform.position.y;
            //Debug.Log(string.Format("Delta H: {0}", deltaH));
            if (deltaH > 0.6 && isJumpReady)
            {
                Vector3 jump = new Vector3(0, 5, 0);
                rigidbody.velocity = jump;
            }
        }
	}

    void OnCollisionEnter(Collision col)
    {
        //Debug.Log("Jump ready");
        if (col.gameObject.name == "prop_powerCube")
        {

        }
        isJumpReady = true;
    }
}
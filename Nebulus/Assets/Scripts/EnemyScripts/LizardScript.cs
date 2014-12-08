using UnityEngine;
using System.Collections;

public class LizardScript : MonoBehaviour {
    bool isLive = true;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLive)
        {
            transform.gameObject.SetActive(false);
        }
        
	}
    void OnCollisionEnter(Collision EnemyCollision)
    {
        if (EnemyCollision.gameObject.name == "Bullet")
        {
            isLive = false;
        }
    }
    
}

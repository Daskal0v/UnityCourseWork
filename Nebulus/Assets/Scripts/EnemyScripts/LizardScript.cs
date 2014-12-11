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
    void OnTriggerEnter(Collider BulletCollide)
    {
        if (BulletCollide.gameObject.tag == "Bullet")
        {
            isLive = false;
        }
    }
}

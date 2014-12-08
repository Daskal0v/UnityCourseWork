using UnityEngine;
using System.Collections;

public class DestroyablePlatform : MonoBehaviour {

	// Use this for initialization
   // GameObject Decore;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag=="Destroyable")
        {
            Destroy(collision.gameObject);
            
        }
    }

    //void OnCollisionStay(Collision col)
    //{
    //    if (col.gameObject.tag=="Final")
    //    {
    //        Decore = GameObject.FindGameObjectWithTag("Decore");
    //        Decore.transform.Translate(0f, -10f, 0);
    //    }
    //}
}

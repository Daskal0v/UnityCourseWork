using UnityEngine;
using System.Collections;

public class DestroyablePlatform : MonoBehaviour {

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag=="Destroyable")
        {
            Destroy(collision.gameObject);
            
        }
    }
}

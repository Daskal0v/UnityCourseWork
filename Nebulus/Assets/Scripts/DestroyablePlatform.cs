using UnityEngine;
using System.Collections;

public class DestroyablePlatform : MonoBehaviour {

    bool isDestroyable=false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isDestroyable==true)
        {
             Destroy(gameObject);
        }

    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            isDestroyable = true;
        }
    }
}

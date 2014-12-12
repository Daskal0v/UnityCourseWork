using UnityEngine;
using System.Collections;

public class CharacterPlatformInteraction : MonoBehaviour {
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Destroyable")
        {
            Destroy(collision.gameObject);
        }
    }
}

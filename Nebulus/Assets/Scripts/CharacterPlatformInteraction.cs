using UnityEngine;
using System.Collections;

public class CharacterPlatformInteraction : MonoBehaviour {
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "VanishingPlatform")
        {
            Destroy(collision.gameObject);
        }
    }
}

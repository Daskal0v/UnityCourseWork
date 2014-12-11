using UnityEngine;
using System.Collections;

public class EnemyCollisions : MonoBehaviour {
    public float playerPushedX;
    public float playerPushedZ;

    void OnCollisionEnter(Collision playerCollision)
    {
        if (playerCollision.gameObject.tag == "Player")
        {
            playerCollision.gameObject.transform.position += new Vector3(playerPushedX, -1f * Time.deltaTime, playerPushedZ);
        }
    }
}

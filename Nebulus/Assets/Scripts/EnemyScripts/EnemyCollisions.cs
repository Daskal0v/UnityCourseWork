using UnityEngine;
using System.Collections;

public class EnemyCollisions : MonoBehaviour {
    public float playerPushedX;
    public float playerPushedZ;
    public float pushDistance;

    void OnCollisionEnter(Collision playerCollision)
    {
        if (playerCollision.gameObject.tag == "Player")
        {
            if (pushDistance != 0)
            {
                playerCollision.gameObject.transform.position = new Vector3(
                    playerCollision.gameObject.transform.position.x * pushDistance, 
                    playerCollision.gameObject.transform.position.y, 
                    playerCollision.gameObject.transform.position.z * pushDistance);
            }
            else
            {
                playerCollision.gameObject.transform.position += new Vector3(playerPushedX, -1f * Time.deltaTime, playerPushedZ);
            }
        }
    }
}
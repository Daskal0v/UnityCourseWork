using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {
    public int points = 100;
    void OnTriggerEnter(Collider CharacterCollision)
    {
        if (CharacterCollision.gameObject.tag == "Player")
        {
            transform.gameObject.SetActive(false);
            PlayerPrefs.SetInt("Score",PlayerPrefs.GetInt("Score")+points);
            
        }
    }
}

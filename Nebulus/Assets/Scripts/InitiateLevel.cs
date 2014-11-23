using UnityEngine;
using System.Collections;

public class InitiateLevel : MonoBehaviour 
{
    public float platformSpreadRadius = 5.75f;
    public int numberOfPlatforms = 20;

	// Use this for initialization
	void Start () 
    {
        var levelPlatforms = GameObject.FindGameObjectsWithTag("Platforms");
        int numberOfPlatforms = levelPlatforms.Length;
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            var pos = new Vector3(0, 0, 0);
            Debug.Log("Platform" + i);
            Debug.Log(levelPlatforms[i].transform.position);
            float x = levelPlatforms[i].transform.position.x;
            pos.x = Mathf.Sin(((x - 10) * Mathf.PI * 2) / 36) * platformSpreadRadius;
            pos.y = levelPlatforms[i].transform.position.y;
            pos.z = Mathf.Cos(((x - 10) * Mathf.PI * 2) / 36) * platformSpreadRadius;
            levelPlatforms[i].transform.position = pos;
            Debug.Log(levelPlatforms[i].transform.position);
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
}
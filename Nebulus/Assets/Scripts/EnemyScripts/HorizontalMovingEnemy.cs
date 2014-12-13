using UnityEngine;
using System.Collections;

public class HorizontalMovingEnemy : MonoBehaviour {

    public float speed = 1f;
    private float sign = 1;

    void Start()
    {
    }

    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, speed * Time.deltaTime * sign);
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("OnCollisionEnter");
        sign = -1*sign;
    }
}
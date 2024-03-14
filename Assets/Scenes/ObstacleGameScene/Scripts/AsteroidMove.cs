using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{
    //The speed the asteroid moves at
    public float speed = 1.0f;

    private Vector3 playerPos;
    private Vector3 direction;
    void Awake()
    {
        playerPos = Camera.main.transform.position;
        direction = playerPos - transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, direction, step);
    }
}

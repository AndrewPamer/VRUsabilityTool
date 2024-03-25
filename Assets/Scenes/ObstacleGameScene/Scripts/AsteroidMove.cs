using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{
    //The speed the asteroid moves at
    public float speed = 1.0f;

    //The time is takes to be destroyed
    public float destroyTime = 10.0f;

    //The target the asteroid moves toward
    private GameObject target;

    private Vector3 direction;

    void Awake()
    {
        target = GameObject.Find("StarSparrow");
        direction = target.transform.position - transform.position;
        //Destroy after destroyTime seconds
        Destroy(gameObject, destroyTime);
    }
    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, direction, step);
    }

}

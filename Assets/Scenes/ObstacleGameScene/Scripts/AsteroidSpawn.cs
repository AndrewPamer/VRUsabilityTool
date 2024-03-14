using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidSpawn : MonoBehaviour
{
    // Reference to the Prefab.
    public GameObject[] asteroids;

    //radius of circle around player
    public float radius = 50.0f;

    //Speed of spawning
    public float spawnSpeed = 1.0f;

    public Vector3 playerLocation;

    void Start()
    {
        InvokeRepeating(nameof(SpawnAsteroid), 1.0f, spawnSpeed);
    }

    void Update()
    {
        playerLocation = transform.position;
    }

    void SpawnAsteroid()
    {
        //random angle 0 - 180
        float randomAngle = Random.Range(0, Mathf.PI);

        float x = Mathf.Cos(randomAngle) * radius;
        float z = Mathf.Sin(randomAngle) * radius;

        Vector3 randomSpawnPostition = new Vector3(x, Random.Range(-5,6), z);
        GameObject randomAsteroid = asteroids[Random.Range(0, asteroids.Length)];
        Instantiate(randomAsteroid, randomSpawnPostition, Quaternion.identity);
    }

}

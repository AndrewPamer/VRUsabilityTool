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

    private int difficulty = 2;

    public float spawnsPerSecond;
    private float nextSpawn;

    void Start()
    {
        InvokeRepeating(nameof(SpawnAsteroid), 1.0f, spawnSpeed);
        InvokeRepeating(nameof(AsteroidSpeedIncrease), 10.0f, 30.0f);
    }

    void OnEnable()
    {
        nextSpawn = Time.time;
    }

    void Update()
    {
        playerLocation = transform.position;
    }

    void AsteroidSpeedIncrease()
    {
        this.spawnSpeed /= 2;
        GameObject[] activeAsteroids = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject asteroid in activeAsteroids)
        {
            AsteroidMove asteroidController = asteroid.GetComponent<AsteroidMove>();
            Debug.Log(Mathf.Pow(2, difficulty / 2));
            asteroidController.speed = Mathf.Pow(2, difficulty / 2);
        }
        difficulty++;
    }

    void SpawnAsteroid()
    {
        //random angle 30 - 150
        float randomAngle = Random.Range(Mathf.PI / 6, (5 * Mathf.PI) / 6);

        float x = Mathf.Cos(randomAngle) * radius;
        float z = Mathf.Sin(randomAngle) * radius;

        Vector3 randomSpawnPostition = new Vector3(x, Random.Range(-5,6), z);
        GameObject randomAsteroid = asteroids[Random.Range(0, asteroids.Length)];
        Instantiate(randomAsteroid, randomSpawnPostition, Quaternion.identity);

        AsteroidMove asteroidController = randomAsteroid.GetComponent<AsteroidMove>();
        asteroidController.speed = Mathf.Pow(2, difficulty / 2);
    }

}

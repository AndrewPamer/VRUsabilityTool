using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;
public class AsteroidSpawn : MonoBehaviour
{
    // Reference to the Prefab.
    public GameObject[] asteroids;

    //radius of circle around player
    public float radius = 50.0f;

    //Speed of spawning
    public float defaultSpawnSpeed = 1.0f;

    //The time it takes for the difficulty to increase
    public float timeTillDifficultyIncrease = 30.0f;

    //The canvas that is next to the ship
    public GameObject shipNotificationCanvas;

    public TextMeshProUGUI notificationTextBox;

    public Vector3 playerLocation;

    private int difficulty;

    private float spawnSpeed;




    public void BeginAsteroidSpawn()
    {
        //Get default values
        spawnSpeed = defaultSpawnSpeed;
        difficulty = 1;
        //Begin spawning routines and difficulty routines
        InvokeRepeating(nameof(SpawnAsteroid), 1.0f, spawnSpeed);
        InvokeRepeating(nameof(DifficultyIncrease), timeTillDifficultyIncrease / 2, timeTillDifficultyIncrease);

    }

    public void EndAsteroidSpawn()
    {
        //1. Stop spawning asteroids
        CancelInvoke();

        //2. Destroy all present asteroids
        GameObject[] activeAsteroids = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject asteroid in activeAsteroids)
        {
            Destroy(asteroid);
        }
    }

    void Update()
    {
        playerLocation = transform.position;
    }

    IEnumerator ShowNotification(string notificationText)
    {
        //1. Set the text 
        notificationTextBox.text = notificationText;

        //2. Show the notification
        shipNotificationCanvas.SetActive(true);

        //3. Wait while the animation plays
        yield return new WaitForSeconds(4);

        //4. Disable the canvas
        shipNotificationCanvas.SetActive(false);

    }

    void DifficultyIncrease()
    {
        Debug.Log("Diff up");
        //Increase difficulty 
        difficulty++;
        StartCoroutine(ShowNotification("Difficulty Up!"));
        this.spawnSpeed /= difficulty;
        //Find every asteroid and increase its speed
        GameObject[] activeAsteroids = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject asteroid in activeAsteroids)
        {
            AsteroidMove asteroidController = asteroid.GetComponent<AsteroidMove>();
            Debug.Log(Mathf.Pow(2, difficulty / 2));
            asteroidController.speed = Mathf.Pow(2, difficulty / 2);
        }
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

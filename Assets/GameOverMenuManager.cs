using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameOverMenuManager : MonoBehaviour
{
    public Transform head;
    public float spawnDistance;
    public GameObject menu;
    public Button restartButton;

    public TextMeshProUGUI correctText;
    public TextMeshProUGUI incorrectText;

    public AsteroidSpawn asteroidSpawner;

    private void Awake()
    {
        restartButton.onClick.AddListener(RestartGame);
    }

    public void SetUp(int correct, int incorrect)
    {
        //1. Stop spawning asteroids
        asteroidSpawner.EndAsteroidSpawn();
        //2. Display the menu
        menu.SetActive(true);
        correctText.text = "Questions Correct: " + correct.ToString();
        incorrectText.text = "Questions Incorrect: " + incorrect.ToString();
        //Add a time field later


        menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
        menu.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));
        menu.transform.forward *= -1;
    }

    private void RestartGame()
    {
        //1. Disable the menu
        menu.SetActive(false);

        //2. Restart asteroid spawn
        asteroidSpawner.BeginAsteroidSpawn();
    }


}

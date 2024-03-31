using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    public Transform head;
    public float spawnDistance;
    public GameObject menu;

    public Button startButton;

    public AsteroidSpawn asteroidSpawner;
    void Start()
    {
        menu.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;
        menu.transform.LookAt(new Vector3(head.position.x, menu.transform.position.y, head.position.z));
        menu.transform.forward *= -1;

        startButton.onClick.AddListener(StartGame);

    }

    private void StartGame()
    {
        //1. Disable the menu
        menu.SetActive(false);
        //2. Begin asteroid spawning.
        asteroidSpawner.BeginAsteroidSpawn();
  
    }

}

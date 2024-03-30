using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDetection : MonoBehaviour
{
    public GameOverScreen gameOverScreen;

    private void OnTriggerEnter(Collider other)
    {
        gameOverScreen.Setup(1, 2);
    }

}

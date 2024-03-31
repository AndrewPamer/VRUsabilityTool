using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDetection : MonoBehaviour
{
    public GameOverMenuManager gameOverScreen;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            gameOverScreen.SetUp(1, 2);
        }
    }

}

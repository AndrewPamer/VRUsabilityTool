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
            //TODO: replace 1, 2 with the actual values
            gameOverScreen.SetUp(1, 2);
        }
    }

}

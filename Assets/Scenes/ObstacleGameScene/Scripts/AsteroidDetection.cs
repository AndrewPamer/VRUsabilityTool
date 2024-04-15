using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDetection : MonoBehaviour
{
    public GameOverMenuManager gameOverScreen;
    public QuestionMenuManager questionScreen;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            //TODO: replace 1, 2 with the actual values
            gameOverScreen.SetUp(1, 2);
        }
        else if (other.gameObject.CompareTag("Powerup"))
        {
            Debug.Log("Hit Powerup");
            string[] answers = { "Wrong Answer", "Wrong Answer", "Right Answer", "Wrong Answer" };
            questionScreen.SetUp("Example Question", answers, 2);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public GameObject answers, questions, mainMenu, endScreen, correctText, incorrectText, ball;
    public List<GameObject> question = new List<GameObject>();
    public List<GameObject> texts = new List<GameObject>();
    public AudioSource menuSource, correctSource, incorrectSource, completeSource;
    private Transform ballSpawn;

    public int answerCount = 0;
    private int questionCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        ballSpawn = GameObject.Find("BallSpawn").transform;
    }

    public void StartQuiz()
    {
        menuSource.Play();
        answers.SetActive(true);
        questions.SetActive(true);
        mainMenu.SetActive(false);

    }

    private void NextQuestion()
    {
        if (questionCount < (question.Count - 1))
        {   //Remove old question and activate the next question
            question[questionCount].SetActive(false);
            questionCount++;
            question[questionCount].SetActive(true);
        }
        else 
        {   //end quiz, display end screen
            questions.SetActive(false);
            answers.SetActive(false);
            endScreen.SetActive(true);

            completeSource.Play();
        }

    }

    public void CheckAnswer(string answer)
    {
        answerCount++;

        if (question[questionCount].GetComponent<Question>().correctAnswer == answer)
        {
            //correct answer, proceed to next question
            NextQuestion();
            answerCount = 0;

            //play correct sound
            correctSource.Play();

            //display text
            StartCoroutine(DisplayMessage("correct"));

            //respawn ball
            SpawnBall();
        }
        else if (answerCount == 3)
        {
            NextQuestion();
            answerCount = 0;

            //incorrect answer, play wrong answer sound
            incorrectSource.Play();

            //respawn ball
            SpawnBall();

            //display text
            StartCoroutine(DisplayMessage("incorrect"));
        }
        else
        {
            //incorrect answer, play wrong answer sound
            incorrectSource.Play();

            //respawn ball
            SpawnBall();

            //display text
            StartCoroutine(DisplayMessage("incorrect"));
        }
    }

    public void SpawnBall()
    {
        ball.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        ball.transform.position = ballSpawn.transform.position;
        ball.gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }

    IEnumerator DisplayMessage(string message)
    {
        if (message == "correct")
        {
            correctText.SetActive(true);
        }
        else if (message == "incorrect")
        {
            incorrectText.SetActive(true);
        }

        yield return new WaitForSeconds(3);

        //Set text back to disabled
        correctText.SetActive(false);
        incorrectText.SetActive(false);

        yield return null;
    }

    public void AdjustFont(bool increase)
    {
        menuSource.Play();

        foreach (GameObject text in texts)
        {
            if (increase)
            {
                IncreaseFontSize(text.GetComponent<TextMeshPro>());
            }
            else
            {
                DecreaseFontSize(text.GetComponent<TextMeshPro>());
            }
        }
    }

    public void IncreaseFontSize(TextMeshPro text)
    {
        float newFontSize = (text.fontSize + 1);
        text.fontSize = newFontSize;
    }

    public void DecreaseFontSize(TextMeshPro text)
    {
        float newFontSize = (text.fontSize - 1);
        text.fontSize = newFontSize;
    }

}

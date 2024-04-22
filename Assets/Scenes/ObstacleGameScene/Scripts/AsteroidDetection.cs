using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[System.Serializable]
public class Question
{
    public string question;
    public string[] answers;
    public int correctAnswerIndex;
}

[System.Serializable]
public class Questions
{
    public Question[] quizQuestions;
}



public class AsteroidDetection : MonoBehaviour
{
    public GameOverMenuManager gameOverScreen;
    public QuestionMenuManager questionScreen;

    public TextAsset jsonQFile;

    private Questions questions;

    public int questionsRight = 0;
    public int questionsWrong = 0;
    private void Start()
    {
        //Load in the questions at the start
        questions = JsonUtility.FromJson<Questions>(jsonQFile.text);

        //Question randomQuestion = questions.quizQuestions[Random.Range(0, questions.quizQuestions.Length)];
        Debug.Log(questions.quizQuestions[0].question);
    }





    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //TODO: replace 1, 2 with the actual values
            gameOverScreen.SetUp(questionsRight, questionsWrong);
        }
        else if (other.gameObject.CompareTag("Powerup"))
        {
            Destroy(other.gameObject);
            Debug.Log("Hit Powerup");
            //1. Get a random question from the questions bank
            Question randomQuestion = questions.quizQuestions[Random.Range(0, questions.quizQuestions.Length)];
            questionScreen.SetUp(randomQuestion.question, randomQuestion.answers, randomQuestion.correctAnswerIndex, this);
        }
    }
}

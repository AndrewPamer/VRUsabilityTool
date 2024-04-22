using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestionMenuManager : MonoBehaviour
{
    public Transform head;
    public float spawnDistance;
    public GameObject menu;

    public Transform answerButtonsContainer;

    public GameObject[] answerButtons;

    public TextMeshProUGUI questionText;

    public GameObject answerButtonPrefab;



    public void SetUp(string question, string[] answers, int correctIndex, AsteroidDetection asteroidDetection)
    {
        //Pause the game
        menu.SetActive(true);
        questionText.text = question;
        foreach (GameObject answerButton in answerButtons)
        {
            answerButton.SetActive(false);
        }
        for (int i = 0; i < answers.Length; i++)
        {
            int index = i;
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = answers[i];
            answerButtons[i].GetComponent<Button>().onClick.AddListener(delegate { OnAnswerClick(correctIndex == index, asteroidDetection); });
            answerButtons[i].SetActive(true);
        }
        Time.timeScale = 0;

    }

    void OnAnswerClick(bool isCorrect, AsteroidDetection asteroidDetection)
    {
        if (isCorrect)
        {
            Debug.Log("Nice ??");
            asteroidDetection.questionsRight++;
        }
        else
        {
            Debug.Log("Wrong ??");
            asteroidDetection.questionsWrong++;
        }
        Time.timeScale = 1;
        menu.SetActive(false);
    }
}

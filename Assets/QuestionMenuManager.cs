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

    public TextMeshProUGUI questionText;

    public GameObject answerButtonPrefab;

    public void SetUp(string question, string[] answers, int correctIndex)
    {
        //Pause the game
        menu.SetActive(true);
        questionText.text = question;
        for (int i = 0; i < answers.Length; i++)
        {
            GameObject answerButton = Instantiate(answerButtonPrefab);
            answerButton.transform.SetParent(answerButtonsContainer);
            answerButton.GetComponent<Button>().onClick.AddListener(delegate { OnAnswerClick(i == correctIndex); });
        }
        Time.timeScale = 0;
    }

    void OnAnswerClick(bool isCorrect)
    {

    }
}

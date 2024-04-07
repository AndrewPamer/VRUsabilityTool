using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Question : MonoBehaviour
{
    public string question;
    public string answerA, answerB, answerC, answerD;
    public string correctAnswer;

    private GameObject questionText;
    private GameObject answerAText, answerBText, answerCText, answerDText;
    // Start is called before the first frame update
    void Start()
    {
        questionText = this.gameObject.transform.Find("Question (TMP)").gameObject;
        answerAText = this.gameObject.transform.Find("AnswerA (TMP)").gameObject;
        answerBText = this.gameObject.transform.Find("AnswerB (TMP)").gameObject;
        answerCText = this.gameObject.transform.Find("AnswerC (TMP)").gameObject;
        answerDText = this.gameObject.transform.Find("AnswerD (TMP)").gameObject;

        questionText.GetComponent<TextMeshPro>().text = question;
        answerAText.GetComponent<TextMeshPro>().text = answerA;
        answerBText.GetComponent<TextMeshPro>().text = answerB;
        answerCText.GetComponent<TextMeshPro>().text = answerC;
        answerDText.GetComponent<TextMeshPro>().text = answerD;

        correctAnswer = correctAnswer.ToLower();
    }




}

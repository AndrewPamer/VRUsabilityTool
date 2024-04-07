using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopCheck : MonoBehaviour
{
    private QuizManager qm;
    public string hoopAnswer;

    private void Start()
    {
        qm = GameObject.Find("Quiz Manager").GetComponent<QuizManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ObjectInteractable")
        {
            qm.CheckAnswer(hoopAnswer);
        }
    }

}

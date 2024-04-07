using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawner : MonoBehaviour
{
    private QuizManager qm;

    // Start is called before the first frame update
    void Start()
    {
        qm = GameObject.Find("Quiz Manager").GetComponent<QuizManager>();
    }


    public void OnTriggerEnter(Collider other)
    {
        qm.SpawnBall();
    }

}

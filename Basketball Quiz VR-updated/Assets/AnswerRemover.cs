using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AnswerRemover : MonoBehaviour
{
    public XRSimpleInteractable a, b, c, d;
    public GameObject simulator;

    // Start is called before the first frame update
    void Start()
    {
        if (!simulator.activeInHierarchy)
        {
            Destroy(a);
            Destroy(b);
            Destroy(c);
            Destroy(d);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

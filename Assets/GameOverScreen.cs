using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public TextMeshProUGUI correctText;
    public TextMeshProUGUI incorrectText;



    public void Setup(int correct, int incorrect)
    {
        gameObject.SetActive(true);
        correctText.text = correct.ToString();
        incorrectText.text = incorrect.ToString();
    }
}
  

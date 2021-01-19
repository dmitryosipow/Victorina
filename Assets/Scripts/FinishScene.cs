using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishScene : MonoBehaviour
{
    public Text correctAnswersTotal;
    public Text wrongAnswersTotal;

    public ScoreSO score;
    // Start is called before the first frame update
    void Start()
    {
        correctAnswersTotal.text = score.correctAnswers.ToString();
        wrongAnswersTotal.text = score.wrongAnswers.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

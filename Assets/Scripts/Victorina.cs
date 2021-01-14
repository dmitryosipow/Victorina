using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Victorina : MonoBehaviour
{
    public Image questionImage;

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    public Text questionText;

    public QuestionSO currentQuestion;
    // Start is called before the first frame update
    void Start()
    {
        button1.GetComponentInChildren<Text>().text = currentQuestion.answer1;
        button2.GetComponentInChildren<Text>().text = currentQuestion.answer2;
        button3.GetComponentInChildren<Text>().text = currentQuestion.answer3;
        button4.GetComponentInChildren<Text>().text = currentQuestion.answer4;

        questionImage.sprite = currentQuestion.image;
        questionText.text = currentQuestion.question;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

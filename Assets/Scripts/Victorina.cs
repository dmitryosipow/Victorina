using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class Victorina : MonoBehaviour
{
    public Image questionImage;

    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    public Image heart1;
    public Image heart2;
    public Image heart3;

    public Text questionText;

    public QuestionSO[] questions;
    public ScoreSO score;

    public SceneM sceneManager;

    int currentQuestionIndex;
    int lives;
    QuestionSO[] temporaryQuestions;

    int variantsTotal = 4;
    int hintRemoveTotal = 2;

    // Start is called before the first frame update
    void Start()
    {
        currentQuestionIndex = 0;
        lives = 3;
        score.Reset();

        temporaryQuestions = new QuestionSO[questions.Length];
        questions.CopyTo(temporaryQuestions, 0);
        ShuffleArray(temporaryQuestions);

        SetQuestion();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetQuestion(int questionIndex = -1)
    {
        int index = questionIndex != -1 ? questionIndex : currentQuestionIndex;
        QuestionSO currentQuestion = temporaryQuestions[index];
        button1.GetComponentInChildren<Text>().text = currentQuestion.answer1;
        button2.GetComponentInChildren<Text>().text = currentQuestion.answer2;
        button3.GetComponentInChildren<Text>().text = currentQuestion.answer3;
        button4.GetComponentInChildren<Text>().text = currentQuestion.answer4;

        questionImage.sprite = currentQuestion.image;
        questionText.text = currentQuestion.question;

        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(true);
        button3.gameObject.SetActive(true);
        button4.gameObject.SetActive(true);
    }

    public void SetAnswer(int answerIndex)
    {
        if(temporaryQuestions[currentQuestionIndex].correctAnswer == answerIndex)
        {
            score.CorrectAnswer();
        } else
        {
            score.WrongAnswer();
            lives--;
            UpdateLives();
        }

        currentQuestionIndex++;

        if(currentQuestionIndex > temporaryQuestions.Length - 1)
        {
            FinishGame();
        } else
        {
            SetQuestion();
        }
    }

    void FinishGame()
    {
        sceneManager.LoadScene("FinishScene");
    }

    void UpdateLives()
    {
        switch (lives)
        {

            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            case 3:
            default:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
        }
    }

    void HideVariant(int num)
    {
        switch (num)
        {

            case 1:
                button1.gameObject.SetActive(false);
                break;
            case 2:
                button2.gameObject.SetActive(false);
                break;
            case 3:
                button3.gameObject.SetActive(false);
                break;
            case 4:
                button4.gameObject.SetActive(false);
                break;
        }
    }

    void ShuffleArray(QuestionSO[] inputArray)
    {
        for (int i = inputArray.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            QuestionSO temp = inputArray[i];
            inputArray[i] = inputArray[randomIndex];
            inputArray[randomIndex] = temp;
        }
    }

    public void RemoveWrong()
    {
        List<int> nonRepeatedIndeces = new List<int>();

        for (int i = 1; i <= variantsTotal; i++)
        {
            if (i != temporaryQuestions[currentQuestionIndex].correctAnswer)
            {
                nonRepeatedIndeces.Add(i);
            }
        }
        for (int i = 0; i < hintRemoveTotal; i++)
        {
            int randomIndex = Random.Range(0, nonRepeatedIndeces.Count);
            HideVariant(nonRepeatedIndeces[randomIndex]);
            nonRepeatedIndeces.RemoveAt(randomIndex);
        }
    }
}

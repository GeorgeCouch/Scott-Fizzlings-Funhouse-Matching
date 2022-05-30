﻿using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public Image ScenarioImage;

    public GameObject CorrectImage;
    public GameObject IncorrectImage;

    public bool correctAnswer;



    private void Start()
    {
        GenerateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];
            if (QnA[currentQuestion].correctAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void GenerateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            ScenarioImage.sprite = QnA[currentQuestion].Questions;
            SetAnswers();

            //QnA.RemoveAt(currentQuestion);
        }
        else
        {
            Debug.Log("Out of Questions");
        }



    }

    IEnumerator CorrectAnswer()
    {
        
            CorrectImage.SetActive(true);
            yield return new WaitForSeconds(1f);
            CorrectImage.SetActive(false);
            QnA.RemoveAt(currentQuestion);
            GenerateQuestion();

    }

    IEnumerator IncorrectAnswer()
    {

        IncorrectImage.SetActive(true);
        yield return new WaitForSeconds(1f);
        IncorrectImage.SetActive(false);
        QnA.RemoveAt(currentQuestion);
        GenerateQuestion();

    }
}

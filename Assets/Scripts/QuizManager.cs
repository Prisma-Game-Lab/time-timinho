using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class QuizManager : MonoBehaviour
{
    public List<Question> questions;
    public List<GameObject> options;
    public int currentQuestion;
    public TextMeshProUGUI QuestionText;


    private Question atual;
    private int[] answers;

    // Start is called before the first frame update
    private void Start()
    {
        currentQuestion = 0;
        atual = questions[currentQuestion];

        QuestionText.text = atual.QuestionText;
        setAnswers();
    }

    void setAnswers()
    {
        for (int i = 0; i < options.Count; i++) 
        {
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = atual.PossibleAnswers[i];
        }
    }

    public void selectAnswer(int button)
    {
        print(button);
        answers.Append(button);
        updateQuestion();
    }

    public void updateQuestion()
    {
        if (currentQuestion + 1 < questions.Count)
        {
            currentQuestion += 1;

            atual = questions[currentQuestion];

            QuestionText.text = atual.QuestionText;
            setAnswers();
        }

        else
        {
            /*for(int i = 0; i < answers.Length; i++)
            {
                print(answers[i]);
            }*/
            print("Cabou");
        }
    }

}

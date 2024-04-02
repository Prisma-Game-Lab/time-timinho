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
    public int currentQuestion;
    public TextMeshProUGUI QuestionText;

    public GameObject QuestionPrefab;

    private GridLayoutGroup gridLayoutGroup;
    private Question atual;
    private int[] answers;

    // Start is called before the first frame update
    private void Start()
    {
        gridLayoutGroup = GetComponent<GridLayoutGroup>();

        currentQuestion = 0;
        atual = questions[currentQuestion];

        QuestionText.text = atual.QuestionText;
        setAnswers();
    }

    /*void setAnswers()
    {
        for (int i = 0; i < options.Count; i++) 
        {
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = atual.PossibleAnswers[i];
        }
    }*/

    void setAnswers()
    {
        for (int i = 0; i < atual.PossibleAnswers.Length; i++)
        {
            GameObject btn;
            btn = Instantiate(QuestionPrefab, Vector3.zero, Quaternion.identity);

            btn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = atual.PossibleAnswers[i];

            btn.transform.SetParent(gridLayoutGroup.transform);

            btn.GetComponent<QuestionButton>().index = i;
            
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

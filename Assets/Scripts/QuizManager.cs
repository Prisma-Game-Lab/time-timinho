using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using System;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEditor;
using UnityEngine.Android;

public class QuizManager : MonoBehaviour
{
    public List<Question> questions;
    public int currentQuestion;
    public TextMeshProUGUI QuestionText;

    private List<GameObject> buttons;

    public GameObject QuestionPrefab;

    private GridLayoutGroup gridLayoutGroup;
    private Question atual;
    private int[] answers;

    private int answerCount = 0;

    // Start is called before the first frame update
    private void Start()
    {
        buttons = new List<GameObject>();
        answers = new int[questions.Count];

        gridLayoutGroup = GetComponent<GridLayoutGroup>();

        currentQuestion = 0;
        atual = questions[currentQuestion];

        QuestionText.text = atual.QuestionText;
        setAnswers();
    }

    void setAnswers()
    {
        for (int i = 0; i < atual.PossibleAnswers.Length; i++)
        {
            GameObject btn = Instantiate(QuestionPrefab, Vector3.zero, Quaternion.identity) as GameObject;

            btn.GetComponent<QuestionButton>().Init(i, this);

            btn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = atual.PossibleAnswers[i];

            btn.transform.SetParent(gridLayoutGroup.transform);

            btn.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
            
            buttons.Add(btn);
        }
    }

    void clearAnswers()
    {
        for(int i = 0; i < buttons.Count; i++)
        {
            Destroy(buttons[i]);
        }
        buttons.Clear();
    }

    public void selectAnswer(int buttonIndex)
    {
        print(buttonIndex);
        answers[answerCount] = buttonIndex;
        answerCount++;
        updateQuestion();
    }

    public void updateQuestion()
    {
        if (currentQuestion + 1 < questions.Count)
        {
            clearAnswers();

            currentQuestion += 1;

            atual = questions[currentQuestion];

            QuestionText.text = atual.QuestionText;
            setAnswers();
        }

        else
        {
            for(int i = 0; i < answers.Length; i++)
            {
                print(answers[i]);
            }

            GameManager.Instance.setMiudoAnswers(answers);
        }
    }

}

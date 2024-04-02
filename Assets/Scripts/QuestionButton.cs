using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestionButton : MonoBehaviour
{
    public QuizManager script;
    public int index;

    private void Start()
    {
        script = GetComponent<QuizManager>();
    }

    public void selectQuestion()
    {
        script.selectAnswer(index);
    }
}

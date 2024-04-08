using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuestionButton : MonoBehaviour
{
    private QuizManager script;
    private int index;

    public void Init(int index, QuizManager script)
    {
        this.index = index;
        this.script = script;
    }

    public int getIndex()
    {
        return index;
    }

    public void selectQuestion()
    {
        script.selectAnswer(this.index);

    }
}

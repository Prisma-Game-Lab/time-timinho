using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Nova Pergunta", menuName = "Pergunta")]
public class Question : ScriptableObject
{
    public string QuestionText;
    public string[] PossibleAnswers;
}

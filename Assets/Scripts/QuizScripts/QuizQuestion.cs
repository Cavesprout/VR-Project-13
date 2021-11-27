using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizData
{
    List<string> questions;
    List<List<string>> answers;
    public QuizData(List<string> Questions, List<List<string>> Answers)
    {
        questions = Questions;
        answers = Answers;
    }
}
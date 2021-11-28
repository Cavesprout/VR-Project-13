using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizBoardController : MonoBehaviour
{
    public GameObject QuizTitle;
    public GameObject titleTXT;
    public GameObject questionBG;
    public GameObject questionTXT;
    public GameObject ErrorTXT;
    public GameObject ErrorOk;
    public GameObject EndScreen;
    public GameObject[] answerBG = new GameObject[4];
    public GameObject[] answerTXT = new GameObject[4];
    public GameObject[] answerPicker = new GameObject[4];
    public GameObject[] answerField = new GameObject[4];

    private bool quizChosen;
    private int questionCounter;
    private int activeQuestion;
    private int selectedAnswer;
    private int questionSetterI;
    public QuizData ActiveQuiz;
    private List<int> QuestionsIncorrect;

    private void Start()
    {
        ActiveQuiz = LoadExampleQuiz();
        quizChosen = true;
        
        StartQuiz();
    }

    // Declarations and functions for storing and loading quiz data

    public struct QuizData
    {
        public QuizData(string title, List<string> questions, List<List<string>> answers, List<int> correctAnswers)
        {
            Title = title;
            Questions = questions;
            Answers = answers;
            CorrectAnswers = correctAnswers;
        }
        public string Title { get; }
        public List<string> Questions { get; }
        public List<List<string>> Answers { get; }
        public List<int> CorrectAnswers { get; }
    }

    QuizData LoadExampleQuiz()
    {
        // Data Input for Quiz
        int qidx;
        string Title = "Example Quiz";
        List<string> Questions = new List<string>();
        List<List<string>> Answers = new List<List<string>>();
        List<int> CorrectAnswers = new List<int>();

        // Add Question 0
        qidx = 0;
        Questions.Add($"Question {qidx}: The Correct Answer is Choice 0");
        Answers.Add(new List<String>());
        Answers[qidx].Add("Choice 0");
        Answers[qidx].Add("Choice 1");
        CorrectAnswers.Add(0);

        // Add Question 1
        qidx++;
        Questions.Add($"Question {qidx}: The Correct Answer is Choice 2");
        Answers.Add(new List<String>());
        Answers[qidx].Add("Choice 0");
        Answers[qidx].Add("Choice 1");
        Answers[qidx].Add("Choice 2");
        CorrectAnswers.Add(2);

        // Add Question 1
        qidx++;
        Questions.Add($"Question {qidx}: The Correct Answer is Choice 1");
        Answers.Add(new List<String>());
        Answers[qidx].Add("Choice 0");
        Answers[qidx].Add("Choice 1");
        Answers[qidx].Add("Choice 2");
        Answers[qidx].Add("Choice 3");
        CorrectAnswers.Add(1);

        // Load into struct
        QuizData ExData = new QuizData(Title, Questions, Answers, CorrectAnswers);
        return ExData;
    }

    QuizData LoadGeneralSafetyQuiz()
    {
        // Data Input for General Safety Quiz
        int qidx;
        string Title = "Example Quiz";
        List<string> Questions = new List<string>();
        List<List<string>> Answers = new List<List<string>>();
        List<int> CorrectAnswers = new List<int>();

        // Add Question 1
        qidx = 0;
        Questions.Add($"Question {qidx}: The successful completion of this quiz gives me access to");
        Answers.Add(new List<String>());
        Answers[qidx].Add("all equipment in the Makerspace, including the 3D printers and the laser cutter.");
        Answers[qidx].Add("none of the equipment in the Makerspace.");
        Answers[qidx].Add("only the hand tools, the button maker, and the vinyl cutter.");
        CorrectAnswers.Add(2);

        // Add Question 2
        qidx++;
        Questions.Add($"Question {qidx}: What is the only piece of machinery in the Makerspace that can be left running while unattended? ");
        Answers.Add(new List<String>());
        Answers[qidx].Add("Laser cutter");
        Answers[qidx].Add("Othermill");
        Answers[qidx].Add("3D printers");
        CorrectAnswers.Add(2);

        // Add Question 3
        qidx++;
        Questions.Add($"Question {qidx}: True or False, it is acceptable to use the space if Makerspace staff are not on duty.");
        Answers.Add(new List<String>());
        Answers[qidx].Add("True");
        Answers[qidx].Add("False");
        CorrectAnswers.Add(1);

        // Add Question 4
        qidx++;
        Questions.Add($"Question {qidx}: What is the correct response to an incident or injury?");
        Answers.Add(new List<String>());
        Answers[qidx].Add("Alert an intern");
        Answers[qidx].Add("Leave the space immediately without notifying anyone");
        Answers[qidx].Add("Ignore the injury and continue working");
        Answers[qidx].Add("Discretely try to treat yourself");
        CorrectAnswers.Add(0);

        // Add Question 5
        qidx++;
        Questions.Add($"Question {qidx}: What kind of foot wear is acceptable when working with blades in the Makerspace?");
        Answers.Add(new List<String>());
        Answers[qidx].Add("Closed-toe shoes");
        Answers[qidx].Add("Any open-toe shoes");
        Answers[qidx].Add("Flip flops");
        CorrectAnswers.Add(0);


        // Add Question 6
        qidx++;
        Questions.Add($"Question {qidx}: Red tape on a tool means:");
        Answers.Add(new List<String>());
        Answers[qidx].Add("Safety glasses are required ");
        Answers[qidx].Add("The tool is damaged and should not be used");
        Answers[qidx].Add("Additional training is required before use");
        CorrectAnswers.Add(0);

        // Add Question 7
        qidx++;
        Questions.Add($"Question {qidx}: True or false, you are allowed to eat food or drink in the Makerspace.");
        Answers.Add(new List<String>());
        Answers[qidx].Add("False");
        Answers[qidx].Add("True");
        CorrectAnswers.Add(0);

        // Add Question 8
        qidx++;
        Questions.Add($"Question {qidx}: What should you do if you want to talk to a friend while they are using a tool?");
        Answers.Add(new List<String>());
        Answers[qidx].Add("Wait until they are done operating the equipment");
        Answers[qidx].Add("Wave your arms to get them to look at you");
        Answers[qidx].Add("Tap them on the shoulder to get their attention");
        CorrectAnswers.Add(0);

        // Add Question 9
        qidx++;
        Questions.Add($"Question {qidx}: Where is the fire extinguisher located?");
        Answers.Add(new List<String>());
        Answers[qidx].Add("There isn't one");
        Answers[qidx].Add("Down the hall");
        Answers[qidx].Add("To the left of the laser cutters");
        CorrectAnswers.Add(2);

        // Add Question 10
        qidx++;
        Questions.Add($"Question {qidx}: What must you do before leaving the Makerspace?");
        Answers.Add(new List<String>());
        Answers[qidx].Add("Tell an intern that you're leaving");
        Answers[qidx].Add("Nothing");
        Answers[qidx].Add("Ensure that your work area is clean, including sweeping the floor");
        CorrectAnswers.Add(2);
        
        // Load into struct
        QuizData GSQuizData = new QuizData(Title, Questions, Answers, CorrectAnswers);
        return GSQuizData;
    }

    QuizData LoadLaserCutterQuiz()
    {
        // Data Input for General Safety Quiz
        int qidx;
        string Title = "Example Quiz";
        List<string> Questions = new List<string>();
        List<List<string>> Answers = new List<List<string>>();
        List<int> CorrectAnswers = new List<int>();

        // Add Question 1
        qidx = 1;
        Questions.Add($"Question {qidx}: Which of these materials is flammable when laser cutting?");
        Answers[qidx].Add("All of these ");
        Answers[qidx].Add("Acrylic ");
        Answers[qidx].Add("Wood ");
        Answers[qidx].Add("Paper ");
        CorrectAnswers.Add(0);

        // Add Question 2
        qidx = 2;
        Questions.Add($"Question {qidx}: What signifies objects as vector shapes that will be traced (cut or scored) by the laser?");
        Answers[qidx].Add("Lineweight is set to .001” or less ");
        Answers[qidx].Add("Color ");
        Answers[qidx].Add("Assigning objects to a layer named “vector” ");
        CorrectAnswers.Add(0);

        // Add Question 3
        qidx = 3;
        Questions.Add($"Question {qidx}: What signifies, to the laser software, to raster/engrave the interior of a shape onto a material?");
        Answers[qidx].Add("Blue stroke ");
        Answers[qidx].Add("Black/Grayscale fill ");
        Answers[qidx].Add("Red stroke ");
        CorrectAnswers.Add(1);

        // Add Question 4
        qidx = 4;
        Questions.Add($"Question {qidx}: Adobe Illustrator is our recommended program to send jobs to the laser cutter/engraver");
        Answers[qidx].Add("True ");
        Answers[qidx].Add("False ");
        CorrectAnswers.Add(0);

        // Add Question 5
        qidx = 5;
        Questions.Add($"Question {qidx}: When selecting the correct material preset and setting the material thickness, it is guaranteed to cut through the material.");
        Answers[qidx].Add("True ");
        Answers[qidx].Add("False ");
        CorrectAnswers.Add(1);

        // Add Question 6
        qidx = 6;
        Questions.Add($"Question {qidx}: The lasers in the Makerspace can cut through aluminum.");
        Answers[qidx].Add("True ");
        Answers[qidx].Add("False ");
        CorrectAnswers.Add(1);

        // Add Question 7
        qidx = 7;
        Questions.Add($"Question {qidx}: The focal distance from the lens to the top of your material is different for each material");
        Answers[qidx].Add("True ");
        Answers[qidx].Add("False ");
        CorrectAnswers.Add(1);

        // Add Question 8
        qidx = 8;
        Questions.Add($"Question {qidx}: PVC (Polyvinyl Chloride) is a laser-safe material.");
        Answers[qidx].Add("True ");
        Answers[qidx].Add("False ");
        CorrectAnswers.Add(1);

        // Add Question 9
        qidx = 9;
        Questions.Add($"Question {qidx}: If you have an uncommon material that shop staff are not sure is laser-safe...");
        Answers[qidx].Add("Test small cuts with the laser ");
        Answers[qidx].Add("Obtain a Safety Data Sheet (SDS) from the manufacturer to find out if it is toxic or corrosive when burned");
        Answers[qidx].Add("Ask a friend ");
        CorrectAnswers.Add(1);

        // Add Question 10
        qidx = 10;
        Questions.Add($"Question {qidx}: When is it okay to leave the laser running unattended?");
        Answers[qidx].Add("For restroom breaks ");
        Answers[qidx].Add("Never. Its required to be watching it run. ");
        Answers[qidx].Add("When the fire alarm goes off ");
        Answers[qidx].Add("As long as you or a buddy are in the room ");
        CorrectAnswers.Add(1);

        // Load into struct
        QuizData LCQuizData = new QuizData(Title, Questions, Answers, CorrectAnswers);
        return LCQuizData;
    }

    // Functions for operation of the quiz board

    private void InitiateQuiz(QuizData selectedQuiz)
    {
        ActiveQuiz = selectedQuiz;
    }

    // Complete
    public void ShowError(string message)
    {
        ErrorTXT.SetActive(true);
        ErrorTXT.GetComponent<TMPro.TextMeshPro>().SetText(message);
    }
    
    // Complete
    public void HideError()
    {
        ErrorTXT.SetActive(false);
    }

    // 
    // Summary:
    //   Changes the user's selection
    //
    //  Parameters:
    //    answerNum:
    //      The index of the answer picked
    public void PickChoice(int answerNum)
    {
        if (selectedAnswer != -1)
        {
            answerPicker[selectedAnswer].GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        }
        answerPicker[answerNum].GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        selectedAnswer = answerNum;
    }

    public void SubmitAnswer()
    {
        if (selectedAnswer == -1)
        {
            ShowError("Please select an Answer");
            return;
        }
        if (ActiveQuiz.CorrectAnswers[activeQuestion] != selectedAnswer)
        {
            QuestionsIncorrect.Add(activeQuestion);
        }
        answerPicker[selectedAnswer].GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        selectedAnswer = -1;
        if (activeQuestion == ActiveQuiz.Questions.Count - 1)
        {
            EndQuiz();
        } else
        {
            NextQuestion();
        }
        
    }

    public void StartQuiz()
    {
        if (quizChosen == true)
        {
            EndScreen.SetActive(false);
            selectedAnswer = -1;
            QuestionsIncorrect = new List<int>();
            activeQuestion = 0;
            titleTXT.GetComponent<TMPro.TextMeshPro>().SetText(ActiveQuiz.Title);
            questionTXT.GetComponent<TMPro.TextMeshPro>().SetText(ActiveQuiz.Questions[activeQuestion]);
            questionSetterI = 0;
            for (questionSetterI = 0; questionSetterI < ActiveQuiz.Answers[activeQuestion].Count; questionSetterI++)
            {
                answerField[questionSetterI].SetActive(true);
                answerTXT[questionSetterI].GetComponent<TMPro.TextMeshPro>().SetText(ActiveQuiz.Answers[activeQuestion][questionSetterI]);
            }
            for (questionSetterI = questionSetterI; questionSetterI < 4; questionSetterI++)
            {
                answerField[questionSetterI].SetActive(false);
            }

            
        }
        else
        {
            Debug.Log("No Quiz Chosen");
        }
    }

    public void EndQuiz()
    {
        string incorrectQuestionString = "";
        titleTXT.GetComponent<TMPro.TextMeshPro>().SetText($"You have reached the end of the {ActiveQuiz.Title}!");
        if (QuestionsIncorrect.Count > 0)
        {
            for (int i = 0; i < QuestionsIncorrect.Count - 1; i++)
            {
                incorrectQuestionString += QuestionsIncorrect[i];
                incorrectQuestionString += ", ";
            }
            incorrectQuestionString += QuestionsIncorrect[QuestionsIncorrect.Count - 1];
            questionTXT.GetComponent<TMPro.TextMeshPro>().SetText($"You scored {ActiveQuiz.Questions.Count - QuestionsIncorrect.Count}/{ActiveQuiz.Questions.Count}. \n" +
            $"You answered questions {incorrectQuestionString} incorrectly.");
        } else
        {
            questionTXT.GetComponent<TMPro.TextMeshPro>().SetText($"You scored {ActiveQuiz.Questions.Count - QuestionsIncorrect.Count}/{ActiveQuiz.Questions.Count}. \n" +
            "Congratulations!");
        }
        
        foreach (GameObject g in answerField)
        {
            g.SetActive(false);
        }
        EndScreen.SetActive(true);
    }

    private void NextQuestion()
    {
        activeQuestion++;
        questionTXT.GetComponent<TMPro.TextMeshPro>().SetText(ActiveQuiz.Questions[activeQuestion]);
        questionSetterI = 0;
        for (questionSetterI = 0; questionSetterI < ActiveQuiz.Answers[activeQuestion].Count; questionSetterI++)
        {
            answerField[questionSetterI].SetActive(true);
            answerTXT[questionSetterI].GetComponent<TMPro.TextMeshPro>().SetText(ActiveQuiz.Answers[activeQuestion][questionSetterI]);
        }
        for (questionSetterI = questionSetterI; questionSetterI < 4; questionSetterI++)
        {
            answerField[questionSetterI].SetActive(false);
        }
    }
}
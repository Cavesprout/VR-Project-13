using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public class TutorialStep
    {
        public TutorialStep(int index, string description, bool completed)
        {
            Index = index;
            Description = description;
            Completed = completed;
        }
        public int Index { get; }
        public string Description { get; }
        public bool Completed { get; set; }
    }
    public AudioManager audioManager;
    GameObject[] UITXT;

    List<TutorialStep> Tutorial;
    public static TutorialController instance;
    int indexOfLastCompletedGroup;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            instance.audioManager = FindObjectOfType<AudioManager>();
            // instance.UITXT = GameObject.FindGameObjectsWithTag("UITXT");
        }
        else
        {
            // instance.UITXT = GameObject.FindGameObjectsWithTag("UITXT");
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        // Populate Tutorial with steps
        Tutorial = new List<TutorialStep>();

        // Play audio: Menu
        Tutorial.Add(new TutorialStep(0, "Enter Laser Cutter Tutorial", false));

        // Play audio: General -> Safety 1 -> Safety 2 -> Safety 3
        Tutorial.Add(new TutorialStep(1, "Open Project to Print", false));

        // Play audio: Step 1 Intro -> Step Adobe Illustrator -> Step 1.1 -> Step 1.2 -> Step 1.3 -> Step 1.4 -> Step 1.5 -> Step 2 Intro -> Step 2.1
        Tutorial.Add(new TutorialStep(2, "Select File -> Print", false));

        // Grouped
        // Play Audio: Step 2.2
        Tutorial.Add(new TutorialStep(3, "Send to the Epilog Engraver WinX64 Fusion Printer", false));
        Tutorial.Add(new TutorialStep(4, "Mark the Placement as 0,0", false));

        // Grouped
        // Play Audio: Step 3 Intro -> Step 3.1
        Tutorial.Add(new TutorialStep(5, "Open Top Door to Load Material.", false));
        Tutorial.Add(new TutorialStep(6, "Position Material Correctly", false));
        Tutorial.Add(new TutorialStep(7, "Turn on Laser Cutter", false));

        // Grouped
        // Play Audio: Step 3.2
        Tutorial.Add(new TutorialStep(8, "Put Laser Tool On Nozzle", false));
        Tutorial.Add(new TutorialStep(9, "Use the Down Arrow to Access the Focus Menu", false));
        Tutorial.Add(new TutorialStep(10, "Use Joystick to Move Workbed Up or Down so that the Tip of the Focus Tool Touches the Material", false));

        // Grouped
        // Play Audio: Step 3.3
        Tutorial.Add(new TutorialStep(11, "Close the Top Door", false));
        Tutorial.Add(new TutorialStep(12, "Check that the Air Filter is Running", false));
        Tutorial.Add(new TutorialStep(13, "Check that the Air Compressor is Flowing", false));


        Tutorial.Add(new TutorialStep(14, "Press the Go button on the Laser Cutter to Complete the Job", false));

        Tutorial.Add(new TutorialStep(15, "Score 10/10 on the Laser Cutter Quiz", false));
    }

    // Start is called before the first frame update
    void Start()
    {
        CompleteStep(0);
        
        

    }

    public bool CheckIfGroupCompleted(int step)
    {
        switch (step)
        {
            case 3:
            case 4:
                if (Tutorial[3].Completed && Tutorial[4].Completed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case 5:
            case 6:
            case 7:
                if (Tutorial[5].Completed && Tutorial[6].Completed && Tutorial[7].Completed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case 8:
            case 9:
            case 10:
                if (Tutorial[8].Completed && Tutorial[9].Completed && Tutorial[10].Completed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case 12:
            case 13:
                if (Tutorial[12].Completed && Tutorial[13].Completed)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            default:
                if (Tutorial[step].Completed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
        }
    }

    public void CompleteStep(int step)
    {
        Tutorial[step].Completed = true;
        if (CheckIfGroupCompleted(step))
        {
            StartNextStage(step);
        }
    }

    public void StartNextStage(int lastStepCompleted)
    {
        List<string> soundsToPlay = new List<string>();
        switch (lastStepCompleted)
        {
            case 0:
                soundsToPlay.Add("General");
                soundsToPlay.Add("Safety 1");
                soundsToPlay.Add("Safety 2");
                soundsToPlay.Add("Safety 3");
                break;
            case 1:
                soundsToPlay.Add("Step 1 Intro");
                soundsToPlay.Add("Step Adobe Illustrator");
                soundsToPlay.Add("Step 1.1");
                soundsToPlay.Add("Step 1.2");
                soundsToPlay.Add("Step 1.3");
                soundsToPlay.Add("Step 1.4");
                soundsToPlay.Add("Step 1.5");
                soundsToPlay.Add("Step 2 Intro");
                soundsToPlay.Add("Step 2.1");
                break;

            case 2:
                soundsToPlay.Add("Step 2.2");
                break;

            case 3:
            case 4:
                soundsToPlay.Add("Step 3 Intro");
                soundsToPlay.Add("Step 3.1");
                break;

            case 5:
            case 6:
            case 7:
                soundsToPlay.Add("3.2");
                break;

            case 8:
            case 9:
            case 10:
                soundsToPlay.Add("3.3");
                break;

            case 11:

                break;

            case 12:
            case 13:

                break;
            case 14:

                break;
            case 15:

                break;

            default:

                break;
        }
        audioManager.PlaySounds(soundsToPlay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

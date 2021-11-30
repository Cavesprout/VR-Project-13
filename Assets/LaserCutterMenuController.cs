using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCutterMenuController : MonoBehaviour
{



    public GameObject goButton;
    public GameObject stopButton;
    public GameObject reset;
    public GameObject navUp;
    public GameObject navDown;
    public GameObject laserPointerRed;
    public GameObject laserPointerWhite;
    public GameObject text;
    string[] menuText = new string[7];

    string jobName;

    int rasterPower;

    int vectorPower;

    int rasterSpeed;

    int vectorSpeed;

    float focus;

    TimeSpan timeElapsed;

    int DPI;

    float jogX, jogY;

    public void goButtonPressed() {

    }

    public void stopButtonPressed() { }

    public void resetButtonPressed() { }

    public void upButtonPressed() { }

    public void downButtonPressed() { }

    public void redButtonPressed() { }

    public void whiteButtonPressed() { }

    public void changeText() { }

    // Start is called before the first frame update
    void Start()
    {
        jobName = "ClemsonPaw";
        rasterPower = 050;
        vectorPower = 050;
        rasterSpeed = 050;
        vectorSpeed = 050;
        focus = 0.000f;
        DPI = 600;
        jogX = 0.00f;
        jogY = 0.00f;
        timeElapsed = new TimeSpan(0, 0, 0, 0);
        menuText[0] = "Version\n001.000.003.000";
        menuText[1] = "Job:" + jobName + "\n" + timeElapsed + "  " + DPI;
        menuText[2] = "Job:" + jobName+"\nFOCUS:"+focus;
        menuText[3] = "Job:" + jobName + "\n" + jogX + "  " + jogY;
        menuText[4] = "Job:" + jobName + "\nRS=" + rasterSpeed + "%  VS=" + vectorSpeed + "%";
        menuText[5] = "Job:"+ jobName + "\nRP="+rasterPower+"%  VP="+ vectorPower+"%" ;
        menuText[6] = "Restore XY Home";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

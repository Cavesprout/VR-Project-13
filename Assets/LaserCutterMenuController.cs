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

    public GameObject Slider;
    public GameObject SliderBar;
    public GameObject Workbed;

    string[] menuText = new string[7];

    string jobName;

    int currentMenu, minMenu, maxMenu;

    int rasterPower;

    int vectorPower;

    int rasterSpeed;

    int vectorSpeed;

    float focus;

    bool poweredOn;

    TimeSpan timeElapsed;

    int DPI;

    // jogX must stay between 0.0 and 3.75
    // jogY must stay between 0.0 and 2.0
    float jogX, jogY;
    float jogXMin, jogXMax, jogYMin, jogYMax;
    float bedHeight, bedHeightMin, bedHeightMax;

    public void JogX(float deltaX)
    {
        jogX += deltaX;
        if (jogX > jogXMax)
        {
            jogX = jogXMax;
        } 
        else if (jogX < jogXMin)
        {
            jogX = jogXMin;
        }
        Slider.transform.localPosition = new Vector3(2f - jogX, 0f, 0f);
    }
    public void JogY(float deltaY)
    {
        jogY += deltaY;
        if (jogY > jogYMax)
        {
            jogY = jogYMax;
        }
        else if (jogY < jogYMin)
        {
            jogY = jogYMin;
        }
        SliderBar.transform.localPosition = new Vector3(0f, 0f, jogY);
    }

    public void ChangeBedHeight(float deltaBedHeight)
    {
        bedHeight += deltaBedHeight;
        if (bedHeight > bedHeightMax)
        {
            bedHeight = bedHeightMax;
        }
        else if (bedHeight < bedHeightMin)
        {
            bedHeight = bedHeightMin;
        }
        Workbed.transform.localPosition = new Vector3(0f, bedHeight, 0f);
    }

    public void powerButtonPressed()
    {
        if (poweredOn == false)
        {

        }
        else
        {
            poweredOn = false;
            changeText("");
        }
    }

    // Check all variables to see if job is ready to start (file sent to laser cutter, properly homed, properly focused)
    public void goButtonPressed()
    {

    }

    public void stopButtonPressed()
    {

    }

    public void resetButtonPressed()
    {

    }

    // Navigate one menu up
    public void upButtonPressed() 
    {
        changeMenu(-1);
    }

    // Navigate one menu down
    public void downButtonPressed()
    {
        changeMenu(1);
    }

    // Show red laser pointer
    public void redButtonPressed()
    {

    }

    // Show white laser pointer
    public void whiteButtonPressed()
    {
        
    }

    public void joystickRight()
    {
        switch (currentMenu)
        {
            // Focus Menu
            case 2:
                break;
            // Jog Menu
            case 3:
                JogX(0.1f);
                break;
            default:
                break;
        }
    }

    public void joystickLeft()
    {
        switch (currentMenu)
        {
            // Focus Menu
            case 2:
                break;
            // Jog Menu
            case 3:
                JogX(-0.1f);
                break;
            default:
                break;
        }
    }

    public void joystickUp()
    {
        switch (currentMenu)
        {
            // Focus Menu
            case 2:
                ChangeBedHeight(0.1f);
                break;
            // Jog Menu
            case 3:
                JogY(-0.1f);
                break;
            default:
                break;
        }
    }

    public void joystickDown()
    {
        switch (currentMenu)
        {
            // Focus Menu
            case 2:
                ChangeBedHeight(-0.1f);
                break;
            // Jog Menu
            case 3:
                JogY(-0.1f);
                break;
            default:
                break;
        }
    }

    public void joystickButtonPressed()
    {
        switch (currentMenu)
        {
            // Jog Menu
            case 3:
                break;
            // Reset XY Menu
            case 6:
                jogX = 0;
                jogY = 0;
                JogX(0);
                JogY(0);
                break;
            default:
                break;
        }
    }

    // Set the text on the menu screen
    public void changeText(string newText)
    {
        text.GetComponent<TMPro.TextMeshPro>().SetText(newText);
    }

    // Go {deltaMenu} menus up or down
    void changeMenu(int deltaMenu)
    {
        currentMenu += deltaMenu;
        if (currentMenu > maxMenu)
        {
            currentMenu = minMenu;
        } else if (currentMenu < minMenu)
        {
            currentMenu = maxMenu;
        }
        changeText(menuText[currentMenu]);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentMenu = 0;
        minMenu = 1;
        maxMenu = 6;
        jogX = 0f;
        jogY = 0f;
        jogXMin = 0f;
        jogXMax = 3.75f;
        jogYMin = 0f;
        jogYMax = 2f;
        bedHeight = 1.2f;
        bedHeightMin = 0f;
        bedHeightMax = 1.5f;
        jobName = "ClemsonPaw";
        rasterPower = 050;
        vectorPower = 050;
        rasterSpeed = 050;
        vectorSpeed = 050;
        focus = 0.000f;
        DPI = 600;
        jogX = 0.00f;
        jogY = 0.00f;
        poweredOn = false;
        timeElapsed = new TimeSpan(0, 0, 0, 0);
        menuText[0] = "Version\n001.000.003.000";
        menuText[1] = $"Job: {jobName} \n{timeElapsed}  +{DPI} DPI";
        menuText[2] = $"Job:{jobName}\nFOCUS:{focus}";
        menuText[3] = $"Job:{jobName}\nX: {jogX} Y: {jogY}";
        menuText[4] = $"Job:{" + jobName + "}\nRS={rasterSpeed}%  VS={vectorSpeed}%";
        menuText[5] = $"Job:{jobName}\nRP={rasterPower}%  VP={vectorPower}%";
        menuText[6] = $"Restore XY Home";

        ChangeBedHeight(0);
        JogX(0);
        JogY(0);
        changeText("");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

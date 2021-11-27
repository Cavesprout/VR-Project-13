using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizAnswerPicker : MonoBehaviour
{
    Material mat;
    private void Start()
    {
        mat = GetComponent<Renderer>().material;
        mat.SetColor("_EmissionColor", Color.green);
    }

    public void HoverOver()
    {
        mat.EnableKeyword("_EMISSION");
    }

    public void HoverEnd()
    {
        mat.DisableKeyword("_EMISSION");
    }
}

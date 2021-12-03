using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkableMaterial : MonoBehaviour
{
    public Material WorkedMat;
    // Start is called before the first frame update
    void Start()
    {
        this.tag = "WorkableMaterial";
    }

    public void SetWorked()
    {
        this.GetComponent<Renderer>().material = WorkedMat;
    }
}

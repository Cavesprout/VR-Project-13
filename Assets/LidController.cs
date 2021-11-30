using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LidController : MonoBehaviour
{
    float newTargetVelo;
    float currentTargetVelo;
    HingeJoint lidHinge;
    JointMotor lidMotor;
    // Start is called before the first frame update
    void Start()
    {
        lidHinge = GetComponent<HingeJoint>();
        lidMotor = lidHinge.motor;
    }

    public void OperateDoor()
    {
        currentTargetVelo = lidMotor.targetVelocity;
        if (currentTargetVelo > 0)
        {
            Debug.Log("Opened Door");
            newTargetVelo = -80;
        } else if (currentTargetVelo < 0)
        {
            Debug.Log("Closed Door");
            newTargetVelo = 80;
        }
        lidMotor.targetVelocity = newTargetVelo;
        lidHinge.motor = lidMotor;
    }
}

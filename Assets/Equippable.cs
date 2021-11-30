using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equippable : MonoBehaviour
{
    public void Equip()
    {
        gameObject.SetActive(false);
    }
}

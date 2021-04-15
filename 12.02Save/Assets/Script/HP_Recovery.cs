using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Recovery : MonoBehaviour
{
    public int Hp_Rec = 20;

    static HP_Recovery instance;
    public static HP_Recovery GetInstance()
    {
        if (instance == null)
        {
            instance = new HP_Recovery();
        }
        return instance;
    }
}

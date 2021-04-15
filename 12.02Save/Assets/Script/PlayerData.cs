﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public readonly int maxHp = 100;
    public int hp;
    public Vector3 savePoint;
    public int savedHp;

    static PlayerData instance;
    public static PlayerData GetInstance()
    {
        if (instance == null)
        {
            instance = new PlayerData();
        }
        return instance;
    }
    PlayerData()
    {
        Reset();
    }
    public void Reset()
    {
        hp = maxHp;

    }

}
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    private void Start()
    {
        Money = startMoney;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cHero : Heroes
{
    protected override void Hero()
    {
        speed = 20f;
        health = 40;
        strength = 10;
        Debug.Log("Stats changed");
    }
}

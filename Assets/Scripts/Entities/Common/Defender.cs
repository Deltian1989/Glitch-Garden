using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : Entity
{
    [SerializeField] int starCost = 100;

    public int GetStarCost()
    {
        return starCost;
    }
}

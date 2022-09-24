using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnome : Shooter
{
    // Start is called before the first frame update
    void Start()
    {
        SetUpShoter();
    }

    // Update is called once per frame
    void Update()
    {
        ToggleAttacking();
    }
}

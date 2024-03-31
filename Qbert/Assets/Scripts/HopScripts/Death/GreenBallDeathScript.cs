using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBallDeathScript : BaseGreenDeathScript
{
    protected override void OnContactDeath()
    {
        //freeze all enemies
        base.OnContactDeath();
    }
}

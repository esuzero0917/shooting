using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointItem : Item
{
    protected override void Get()
    {
        player.nowPoint += point;
        base.Get();
    }
}

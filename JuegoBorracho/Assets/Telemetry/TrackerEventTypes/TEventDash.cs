using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEventDash : TrackerEvent
{
    public TEventDash(float timeStamp, Position2D pos) : base(timeStamp, pos, "PlayerDash")
    {

    }
}

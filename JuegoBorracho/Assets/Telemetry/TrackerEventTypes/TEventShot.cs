using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

public class TEventShot : TrackerEvent
{
    public TEventShot(float timeStamp, Position2D pos) : base(timeStamp, pos, "PlayerShoots")
    {
    
    }
}

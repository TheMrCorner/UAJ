using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
public class TEventPlayerDeath : TrackerEvent
{
    public TEventPlayerDeath(float timeStamp, Position2D pos) : base(timeStamp, pos, "PlayerDeath")
    { 
    
    }
}

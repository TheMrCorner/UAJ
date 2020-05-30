using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
public class TEventInitGame : TrackerEvent
{
    public TEventInitGame(float timeStamp, Position2D pos) : base(timeStamp, pos, "InitLevel")
    {

    }
}

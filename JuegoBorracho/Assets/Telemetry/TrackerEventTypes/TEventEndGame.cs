using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

public class TEventEndGame : TrackerEvent
{
    // -------------------- FUNCIONES -------------------- //

    public TEventEndGame(float timeStamp, Position2D pos) : base(timeStamp, pos, "EndLevel")
    {

    }
}

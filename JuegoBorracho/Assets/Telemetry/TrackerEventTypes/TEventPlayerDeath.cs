using System.Collections;
using System.Collections.Generic;

public class TEventPlayerDeath : TrackerEvent
{
    public TEventPlayerDeath(float timeStamp) : base(timeStamp)
    {

    }
    public override void DumpEventDataToJson()
    {
        throw new System.NotImplementedException();
    }
}

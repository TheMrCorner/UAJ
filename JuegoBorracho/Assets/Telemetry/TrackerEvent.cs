using System.Collections;
using System.Collections.Generic;
using System;

public abstract class TrackerEvent
{

    float timeStamp;
    public TrackerEvent(float timeStamp)
    {
        this.timeStamp = timeStamp;
    }

    public abstract void DumpEventDataToJson();
}

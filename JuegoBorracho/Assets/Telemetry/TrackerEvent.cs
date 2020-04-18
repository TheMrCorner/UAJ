using System.Collections;
using System.Collections.Generic;
using System;

public abstract class TrackerEvent
{

    float timeStamp;
    TrackerEvent(float timeStamp)
    {

    }

    public abstract void DumpEventDataToJson();
}

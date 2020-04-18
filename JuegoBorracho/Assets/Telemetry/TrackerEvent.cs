using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TrackerEvent
{

    float timeStamp;
    TrackerEvent()
    {
        timeStamp = Time.time;
    }

    public abstract void FillEventData();
    public abstract void DumpEventDataToJson();

}

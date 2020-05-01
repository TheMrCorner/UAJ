using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

public abstract class TrackerEvent
{

    float _timeStamp;
    protected string _eventType;
    public TrackerEvent(float timeStamp, string eventType)
    {
        this._timeStamp = timeStamp;
        this._eventType = eventType;
    }

    public virtual void DumpEventDataToJson(ref JSONObject dataFile)
    {
        JSONObject jTime = new JSONObject();
        jTime.Add("Timestamp", this._timeStamp);
        dataFile.Add(this._eventType, jTime);
    }
}

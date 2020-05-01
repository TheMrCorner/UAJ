using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

public abstract class TrackerEvent
{

    protected float _timeStamp;
    protected string _eventType;
    public TrackerEvent(float timeStamp, string eventType)
    {
        this._timeStamp = timeStamp;
        this._eventType = eventType;
    }

    public virtual void DumpEventDataToJson(ref JSONObject dataFile)
    {
        JSONObject jEventType = new JSONObject();
        jEventType.Add("Type", this._eventType);
        dataFile.Add(this._timeStamp.ToString(), jEventType); // this._timeStamp.ToString()
    }
}

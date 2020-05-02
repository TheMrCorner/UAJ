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

    public void DumpEventDataToJson(ref JSONObject dataFile)
    {
        JSONObject jEventType = new JSONObject();
        jEventType.Add("TimeSinceStart", this._timeStamp);
        DumpExtraDataToJson(ref jEventType);
        dataFile.Add(this._eventType, jEventType); 
    }

    protected virtual void DumpExtraDataToJson(ref JSONObject jsonEventType) {}
}

using System.Collections;
using System.Collections.Generic;
using SimpleJSON;



public struct Position2D
{
    public Position2D(float x, float y)
    {
        this.x = x;
        this.y = y;
    }


    public float x;
    public float y;
};


public abstract class TrackerEvent
{
 
    protected float _timeStamp;
    protected string _eventType;
    protected Position2D _pos;

    public TrackerEvent(float timeStamp, Position2D pos, string eventType)
    {
        this._timeStamp = timeStamp;
        this._eventType = eventType;
        this._pos = pos;
    }

    public void DumpEventDataToJson(ref JSONObject dataFile)
    {
        JSONObject jEventType = new JSONObject();
        jEventType.Add("TimeSinceStart", this._timeStamp);

        JSONObject pos = new JSONObject();
        pos.Add("x", _pos.x);
        pos.Add("y", _pos.y);

        jEventType.Add("Position", pos);

        DumpExtraDataToJson(ref jEventType);
        dataFile.Add(this._eventType, jEventType); 
    }

    protected virtual void DumpExtraDataToJson(ref JSONObject jsonEventType) {}
}

using System.Collections;
using System.Collections.Generic;



public class Tracker
{     string FILE_NAME = "Telemetry";

    // -------------------- VARIABLES -------------------- //
    private static Tracker instance;
    private static Queue<TrackerEvent> _eventQueue;


    // -------------------- FUNCIONES -------------------- //
    public static Tracker Instance
    {
        get
        {
            if (instance == null)
                instance = new Tracker();
            return instance;
        }
    }
    // Adds an event to the event queue
    public void AddEvent(ref TrackerEvent trackerEvent)
    {
        _eventQueue.Enqueue(trackerEvent);
    }    // Dumps the set number of events to json     // If numEvents == -1, dumps all the events left in the queue    public void DumpEventsToJson(int numEvents = -1)
    {
        if(_eventQueue.Count > 0)
        {
            if(numEvents > 0)
            {
                for(int i=0; i<numEvents && _eventQueue.Count>0; i++)
                {
                    TrackerEvent auxTE = _eventQueue.Dequeue();
                    auxTE.DumpEventDataToJson();
                }
            }
            else
            {
                while (_eventQueue.Count > 0)
                {
                    TrackerEvent auxTE = _eventQueue.Dequeue();
                    auxTE.DumpEventDataToJson();
                }
            }
        }
    }
}

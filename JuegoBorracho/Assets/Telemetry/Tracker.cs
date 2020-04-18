using System.Collections;
using System.Collections.Generic;


public class Tracker
{

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

    public void AddEvent(ref TrackerEvent trackerEvent)
    {
        _eventQueue.Enqueue(trackerEvent);
    }
}

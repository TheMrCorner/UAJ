using System.Collections;
using System.Collections.Generic;


public class TEventEndGame : TrackerEvent
{
    // -------------------- FUNCIONES -------------------- //

    public TEventEndGame(float timeStamp) : base(timeStamp)
    {
      
    }

    public override void DumpEventDataToJson()
    {
        throw new System.NotImplementedException();
    }
}

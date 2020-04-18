using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEventEnemyDeath : TrackerEvent
{
    public TEventEnemyDeath(float timeStamp) : base(timeStamp)
    {

    }

    public override void DumpEventDataToJson()
    {
        throw new System.NotImplementedException();
    }
}

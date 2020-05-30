using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
public class TEventEnemyDeath : TrackerEvent
{
    public TEventEnemyDeath(float timeStamp, Position2D pos) : base(timeStamp, pos, "EnemyDeath")
    {

    }
}

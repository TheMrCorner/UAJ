using System.Collections;
using System.Collections.Generic;


public class TEventDamage : TrackerEvent
{
    // -------------------- VARIABLES -------------------- //

    float damage; // Daño recibido por el jugador

    // -------------------- FUNCIONES -------------------- //

    public TEventDamage(float timeStamp, float dmg) : base(timeStamp)
    {
        damage = dmg;
    }

    public override void DumpEventDataToJson()
    {
        throw new System.NotImplementedException();
    }
}

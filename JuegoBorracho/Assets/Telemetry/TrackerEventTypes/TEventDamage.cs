using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

public class TEventDamage : TrackerEvent
{
    // -------------------- VARIABLES -------------------- //

    float damage; // Daño recibido por el jugador

    // -------------------- FUNCIONES -------------------- //

    public TEventDamage(float timeStamp, float dmg) : base(timeStamp, "Damaged")
    {
        damage = dmg;
    }

    protected override void DumpExtraDataToJson(ref JSONObject jsonEventType)
    {
        base.DumpExtraDataToJson(ref jsonEventType);
        jsonEventType.Add("DamageValue", this.damage);
    }
}

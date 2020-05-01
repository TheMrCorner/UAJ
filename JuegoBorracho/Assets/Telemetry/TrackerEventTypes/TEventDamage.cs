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

    public override void DumpEventDataToJson(ref JSONObject dataFile)
    {
        base.DumpEventDataToJson(ref dataFile);
        JSONObject jDmg = new JSONObject();
        jDmg.Add("DamageValue", this.damage);
        dataFile.Add(this._eventType, jDmg);
    }
}

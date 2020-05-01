using System.Collections;
using System.Collections.Generic;
using SimpleJSON;


public class TEventChangeState : TrackerEvent
{
    // -------------------- VARIABLES -------------------- //
    public enum State { Ebrio, Sobrio };

    private State state; // Estado al que cambia el jugador


    // -------------------- FUNCIONES -------------------- //
    public TEventChangeState(float timeStamp, State s) : base(timeStamp, "ChangeState")
    {
        state = s;
    }


    public override void DumpEventDataToJson(ref JSONObject dataFile)
    {
        base.DumpEventDataToJson(ref dataFile);
        JSONObject jState = new JSONObject();
        jState.Add("StatedChangedTo", this.state.ToString());
        dataFile.Add(this._eventType, jState);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using SimpleJSON;


public class TEventChangeState : TrackerEvent
{
    // -------------------- VARIABLES -------------------- //
    public enum State { Ebrio, Sobrio };

    private State state; // Estado al que cambia el jugador


    // -------------------- FUNCIONES -------------------- //
    public TEventChangeState(float timeStamp, Position2D pos, State s) : base(timeStamp, pos, "ChangeState")
    {
        state = s;
    }


    protected override void DumpExtraDataToJson(ref JSONObject jsonEventType)
    {
        base.DumpExtraDataToJson(ref jsonEventType);
        jsonEventType.Add("StatedChangedTo", this.state.ToString());
    }
}

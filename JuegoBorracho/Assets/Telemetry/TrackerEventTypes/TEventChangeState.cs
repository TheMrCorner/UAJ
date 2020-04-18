using System.Collections;
using System.Collections.Generic;



public class TEventChangeState : TrackerEvent
{
    // -------------------- VARIABLES -------------------- //
    public enum State { Ebrio, Sobrio };

    private State state; // Estado al que cambia el jugador


    // -------------------- FUNCIONES -------------------- //
    public TEventChangeState(float timeStamp, State s) : base(timeStamp)
    {
        state = s;
    }


    public override void DumpEventDataToJson()
    {
        throw new System.NotImplementedException();
    }
}

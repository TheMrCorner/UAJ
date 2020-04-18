using System.Collections;
using System.Collections.Generic;

public class Tracker
{

    // -------------------- VARIABLES -------------------- //
    private static Tracker instance;



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
}

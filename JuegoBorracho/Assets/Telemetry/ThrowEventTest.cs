using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowEventTest : MonoBehaviour
{
   public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("System.DateTime.Now: " + System.DateTime.Now);
            // Time.timeSinceLevelLoad;

            // Tracker.Instance.AddEvent(new TEventChangeState(System.DateTime, TEventChangeState.State.Ebrio));
        }
    }
}

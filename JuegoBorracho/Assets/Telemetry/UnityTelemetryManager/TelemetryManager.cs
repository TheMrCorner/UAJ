using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelemetryManager : MonoBehaviour
{
    [Tooltip("Amount of events to wait till next data dumping")]
    public int eventStack = 20;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        StartCoroutine(TelemetryCoroutine());
    }    

    IEnumerator TelemetryCoroutine()
    {
        while (Application.isPlaying)
        {
            yield return new WaitUntil(() => Tracker.Instance.GetQueueNumEvents() > eventStack);
            Tracker.Instance.DumpEventsToJson(eventStack);
        }
        yield return null;
    }

    private void OnDestroy()
    {
        Tracker.Instance.DumpEventsToJson();

        StopAllCoroutines();
    }
}

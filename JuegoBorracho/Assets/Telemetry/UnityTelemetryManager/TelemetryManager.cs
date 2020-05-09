using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelemetryManager : MonoBehaviour
{
    [Tooltip("Amount of events to wait till next data dumping")]
    public int _eventStack = 20;
    public FileType _fileType = FileType.Json;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        Tracker.Instance.InitSaveFile(_fileType);
        StartCoroutine(TelemetryCoroutine());
    }    

    IEnumerator TelemetryCoroutine()
    {
        while (Application.isPlaying)
        {
            yield return new WaitUntil(() => Tracker.Instance.GetQueueNumEvents() > _eventStack);
            Tracker.Instance.DumpEventsToFile(_eventStack, _fileType);
        }
        yield return null;
    }

    private void OnDestroy()
    {
        Tracker.Instance.DumpEventsToFile(-1, _fileType);

        StopAllCoroutines();
    }
}

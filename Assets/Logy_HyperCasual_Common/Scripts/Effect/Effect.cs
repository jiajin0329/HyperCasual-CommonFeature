using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Effect : MonoBehaviour {
    [SerializeField] protected bool play_on_awake;
    [SerializeField] protected bool loop;
    [SerializeField] protected ushort play_times;
    public UnityEvent PlayEvent;
    public UnityEvent StopEvent;
    public UnityEvent FinishEvent;

    public void Play() {
        PlayEvent.Invoke();
    }
    public void Stop() {
        StopEvent.Invoke();
    }
    public void Finish() {
        FinishEvent.Invoke();
    }
}

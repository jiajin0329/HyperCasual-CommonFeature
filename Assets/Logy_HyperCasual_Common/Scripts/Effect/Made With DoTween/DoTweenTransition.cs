using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoTweenTransition : Effect {
    [SerializeField] protected UnityEvent PlayEvent;
    [SerializeField] protected UnityEvent FinishEvent;
    [SerializeField] protected UnityEvent EndEvent;

    void Awake() {
        EndEvent.AddListener(FinishDistory);
    }

    protected override IEnumerator DelayPlay(float wait) {
        yield return new WaitForSeconds(wait);
        if(PlayEvent != null) PlayEvent.Invoke();
    }
    protected override IEnumerator DelayFinish(float wait) {
        yield return new WaitForSeconds(wait);
        if(FinishEvent != null) FinishEvent.Invoke();
    }
    protected override IEnumerator DelayEnd(float wait) {
        yield return new WaitForSeconds(wait);
        if(EndEvent != null) EndEvent.Invoke();
    }

    void FinishDistory() {
        if(finish_distory) GameObject.Destroy(gameObject);
    }
}
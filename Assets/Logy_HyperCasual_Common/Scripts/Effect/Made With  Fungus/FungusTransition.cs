using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.Events;

public class FungusTransition : Effect {
    [SerializeField] protected float cost_time;
    [SerializeField] protected Flowchart flowchart;

    [SerializeField] protected UnityEvent PlayEvent;
    [SerializeField] protected UnityEvent FinishEvent;
    [SerializeField] protected UnityEvent EndEvent;

    void Awake() {
        flowchart.SetFloatVariable("cost_time", cost_time);
        EndEvent.AddListener(FinishDistory);
    }

    public override float CostTime() {return cost_time;}

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

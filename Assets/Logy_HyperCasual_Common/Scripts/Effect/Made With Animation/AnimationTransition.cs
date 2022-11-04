using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationTransition : Effect {
    [SerializeField] float cost_time;
    [SerializeField] Animator animator;

    [SerializeField] UnityEvent PlayEvent;
    [SerializeField] UnityEvent FinishEvent;
    [SerializeField] UnityEvent EndEvent;

    void Awake() {
        animator.speed = 1 / cost_time;
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

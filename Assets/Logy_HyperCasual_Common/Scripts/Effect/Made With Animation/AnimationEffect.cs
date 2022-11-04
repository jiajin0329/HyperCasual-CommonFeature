using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEffect : Effect {
    [SerializeField] bool play_on_awake;
    [SerializeField] bool loop;
    [SerializeField] ushort play_times;
    [SerializeField] Animator animator;

    [SerializeField] UnityEvent PlayEvent;
    [SerializeField] UnityEvent StopEvent;
    [SerializeField] UnityEvent FinishEvent;
    [SerializeField] UnityEvent EndEvent;

    byte count = 0;

    void Awake() {
        if(animator == null) GetComponent<Animator>();
    }
    void Start() {
        if(play_on_awake) Play(0f);
    }

    protected override IEnumerator DelayPlay(float wait) {
        yield return new WaitForSeconds(wait);
        ResetCount();
        Procedure();
    }
    protected override IEnumerator DelayStop(float wait) {
        yield return new WaitForSeconds(wait);
        animator.enabled = false;
        StopEvent.Invoke();
    }
    protected override IEnumerator DelayFinish(float wait) {
        yield return new WaitForSeconds(wait);
        FinishEvent.Invoke();
    }
    protected override IEnumerator DelayEnd(float wait) {
        yield return new WaitForSeconds(wait);
        EndEvent.Invoke();
    }

    public void ResetCount() {
        count = 0;
    }

    public void Procedure() {
        if(count > 0) Finish(0f);

        if(count < play_times) {
            animator.enabled = true;
            animator.Play(0);
            PlayEvent.Invoke();
            count++;
            return;
        }

        if(loop) {
            ResetCount();
            Play(0f);
            return;
        }

        End(0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ParticleEffect : Effect {
    [SerializeField] UnityEvent PlayEvent;
    [SerializeField] UnityEvent StopEvent;
    [SerializeField] UnityEvent FinishEvent;
    [SerializeField] UnityEvent EndEvent;

    [SerializeField] new ParticleSystem particleSystem;

    void Awake() {
        if(particleSystem == null) GetComponent<ParticleSystem>();
    }

    protected override IEnumerator DelayPlay(float wait) {
        yield return new WaitForSeconds(wait);
        if(PlayEvent != null) PlayEvent.Invoke();
    }
    protected override IEnumerator DelayStop(float wait) {
        yield return new WaitForSeconds(wait);
        if(StopEvent != null) StopEvent.Invoke();
    }
    protected override IEnumerator DelayFinish(float wait) {
        yield return new WaitForSeconds(wait);
        if(FinishEvent != null) FinishEvent.Invoke();
    }
    protected override IEnumerator DelayEnd(float wait) {
        yield return new WaitForSeconds(wait);
        if(EndEvent != null) EndEvent.Invoke();
    }

    public void PlayParticle(float wait) {
        StartCoroutine(DelayPlayParticle(wait));
    }
    public IEnumerator DelayPlayParticle(float wait) {
        yield return new WaitForSeconds(wait);
        particleSystem.Play();
    }

    public void StopParticle(float wait) {
        StartCoroutine(DelayStopParticle(wait));
    }
    public IEnumerator DelayStopParticle(float wait) {
        yield return new WaitForSeconds(wait);
        particleSystem.Stop(true);
    }
}

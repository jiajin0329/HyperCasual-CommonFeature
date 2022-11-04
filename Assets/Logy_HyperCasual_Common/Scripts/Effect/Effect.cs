using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour {
    public bool finish_distory;

    public void Play(float wait) {
        StartCoroutine(DelayPlay(wait));
    }
    protected virtual IEnumerator DelayPlay(float wait) {
        yield return new WaitForSeconds(wait);
    }
    
    public void Stop(float wait) {
        StartCoroutine(DelayStop(wait));
    }
    protected virtual IEnumerator DelayStop(float wait) {
        yield return new WaitForSeconds(wait);
    }

    public void Finish(float wait) {
        StartCoroutine(DelayFinish(wait));
    }
    protected virtual IEnumerator DelayFinish(float wait) {
        yield return new WaitForSeconds(wait);
    }

    public void End(float wait) {
        StartCoroutine(DelayEnd(wait));
    }
    protected virtual IEnumerator DelayEnd(float wait) {
        yield return new WaitForSeconds(wait);
    }

    public virtual float CostTime() {return 0f;}
}
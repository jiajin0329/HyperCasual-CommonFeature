using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FungusEffect : Effect {
    [SerializeField] bool play_on_awake;
    [SerializeField] bool loop;
    [SerializeField] ushort play_times;
    [SerializeField] Flowchart flowchart;

    byte count = 0;

    void Awake() {
        flowchart.SetBooleanVariable("play_on_awake", play_on_awake);
        flowchart.SetBooleanVariable("loop", loop);
        flowchart.SetIntegerVariable("play_times", play_times);
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
        flowchart.StopAllBlocks();
        flowchart.ExecuteBlock("Stop");
    }
    protected override IEnumerator DelayFinish(float wait) {
        yield return new WaitForSeconds(wait);
        flowchart.ExecuteBlock("Finish");
    }
    protected override IEnumerator DelayEnd(float wait) {
        yield return new WaitForSeconds(wait);
        flowchart.ExecuteBlock("End");
    }
    
    
    public void ResetCount() {
        count = 0;
    }

    public void Procedure() {
        if(count > 0) Finish(0f);

        if(count < play_times) {
            flowchart.ExecuteBlock("Play");
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
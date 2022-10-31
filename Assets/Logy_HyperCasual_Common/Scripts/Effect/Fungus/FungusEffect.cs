using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class FungusEffect : Effect {
    [SerializeField] Flowchart flowchart;

    byte count = 0;

    void Awake() {
        flowchart.SetBooleanVariable("play_on_awake", play_on_awake);
        flowchart.SetBooleanVariable("loop", loop);
        flowchart.SetIntegerVariable("play_times", play_times);

        PlayEvent.AddListener(PlayFlowchart);
        StopEvent.AddListener(StopFlowchart);
    }
    void Start() {
        if(play_on_awake) Play();
    }

    void PlayFlowchart() {
        ResetCount();
        Procedure();
    }
    void StopFlowchart() {
        flowchart.StopAllBlocks();
    }
    
    public void ResetCount() {
        count = 0;
    }

    public void Procedure() {
        if(count < play_times) {
            flowchart.ExecuteBlock("Effect");
            count++;
            return;
        }

        if(loop) {
            ResetCount();
            PlayFlowchart();
            return;
        }

        Finish();
    }
}

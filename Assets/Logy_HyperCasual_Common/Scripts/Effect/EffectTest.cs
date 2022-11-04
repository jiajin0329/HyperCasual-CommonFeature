using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTest : MonoBehaviour {
    [SerializeField] Effect[] effects;
    public void Play() {
        for(byte i = 0; i < effects.Length; i++) {
            effects[i].Play(0f);
        }
    }
    public void Stop() {
        for(byte i = 0; i < effects.Length; i++) {
            effects[i].Stop(0f);
        }
    }

    public void PlayTest() {
        Debug.Log("PlayTest");
    }

    public void StopTest() {
        Debug.Log("StopTest");
    }

    public void FinishTest() {
        Debug.Log("FinishTest");
    }

    public void EndTest() {
        Debug.Log("EndTest");
    }
}
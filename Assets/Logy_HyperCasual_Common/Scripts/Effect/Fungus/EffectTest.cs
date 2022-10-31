using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTest : MonoBehaviour {
    [SerializeField] Effect[] effects;
    public void Play() {
        for(byte i = 0; i < effects.Length; i++) {
            effects[i].Play();
        }
    }
    public void Stop() {
        for(byte i = 0; i < effects.Length; i++) {
            effects[i].Stop();
        }
    }
    public void Finish() {
        for(byte i = 0; i < effects.Length; i++) {
            effects[i].Finish();
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
}
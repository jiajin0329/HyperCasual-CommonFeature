using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCloseFeature : MonoBehaviour {
    [SerializeField] Feature[] features;
    void Start() {
        for(byte i = 0; i < features.Length; i++) {
            features[i].enabled = false;
        }
    }
}

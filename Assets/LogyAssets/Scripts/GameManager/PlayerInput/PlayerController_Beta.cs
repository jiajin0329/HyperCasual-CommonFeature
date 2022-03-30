using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Beta : MonoBehaviour {
    static private PlayerController_Beta playerController;
    private PlayerController_Beta() {}
    [SerializeField] private List<Feature> features;
    
    [SerializeField] private Logy.Input input;

    private void Awake() {
        if(playerController != null) print("this scene have same class");
        else playerController = this;

        features.Add(input);
    }

    private void Update() {
        for(byte i = 0; i< features.Count; i++) {
            features[i].Main();
        }
    }
}
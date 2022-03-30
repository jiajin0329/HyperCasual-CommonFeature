using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    static private PlayerController playerController;
    private PlayerController() {}
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
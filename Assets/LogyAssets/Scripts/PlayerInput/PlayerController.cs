using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    static private PlayerController playerController;
    private PlayerController() {}
    [SerializeField] private Mobile_Input input;
    [SerializeField] private Input_Distance input_Distance;

    private void Awake() {
        if(playerController != null) Debug.Log("this scene have same class");
        else playerController = this;
    }

    private void Update() {
        input.Main();
        input_Distance.Main();
    }
}
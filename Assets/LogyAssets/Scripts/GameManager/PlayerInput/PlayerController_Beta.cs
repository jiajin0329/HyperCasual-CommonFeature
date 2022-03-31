using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Beta : MonoBehaviour {
    static private PlayerController_Beta playerController;
    private PlayerController_Beta() {}
    [SerializeField] private Logy.Input input;
    [SerializeField] private Input_Dis input_Dis;

    private void Awake() {
        if(playerController != null) print("this scene have same class");
        else playerController = this;
    }

    private void Update() {
        input.Main();
        input_Dis.Main();
    }
}
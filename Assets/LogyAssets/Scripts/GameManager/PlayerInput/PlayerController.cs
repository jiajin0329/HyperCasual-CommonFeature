using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    static private PlayerController playerController;
    private PlayerController() {}
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
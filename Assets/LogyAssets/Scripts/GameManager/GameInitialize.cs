using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitialize : MonoBehaviour {
    [SerializeField] private Objects[] OpenObjects;
    [SerializeField] private Objects[] CloseObjects;
    private void Start() {
        Application.targetFrameRate = 60;
        print("set " + Application.targetFrameRate + "fps");

        byte i, j;

        for(i = 0; i < OpenObjects.Length; i++) {
            for(j = 0; j < OpenObjects[i].gameObjects.Length; j++) {
                OpenObjects[i].gameObjects[j].SetActive(true);
            }
        }

        for(i = 0; i < CloseObjects.Length; i++) {
            for(j = 0; j < CloseObjects[i].gameObjects.Length; j++) {
                CloseObjects[i].gameObjects[j].SetActive(false);
            }
        }
    }
}

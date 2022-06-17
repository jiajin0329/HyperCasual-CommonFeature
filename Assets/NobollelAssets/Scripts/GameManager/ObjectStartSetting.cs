using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStartSetting : MonoBehaviour {
    [SerializeField] Objects[] OpenObjects;
    [SerializeField] Objects[] CloseObjects;
    
    [System.Serializable] public struct StartPosition {
        [SerializeField] string name;
        public Transform transform;
        public Vector3 startPosition;
        public Vector3 startAngles;
    }
    [SerializeField] StartPosition[] startPositions;
    void Awake() {
        byte i, j;

        for(i = 0; i < OpenObjects.Length; i++) {
            for(j = 0; j < OpenObjects[i].gameObjects.Length; j++) {
                OpenObjects[i].gameObjects[j].SetActive(true);
            }
        }

        for(i = 0; i < CloseObjects.Length; i++) {
            for(j = 0; j < CloseObjects[i].gameObjects.Length; j++) {
                CloseObjects[i].gameObjects[j].SetActive(false);
                Debug.Log("close object");
            }
        }

        for(i = 0; i < startPositions.Length; i++) {
            startPositions[i].transform.localPosition = startPositions[i].startPosition;
            startPositions[i].transform.localEulerAngles = startPositions[i].startAngles;
        }
    }
}
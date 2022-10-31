using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStartSetting : MonoBehaviour {
    [SerializeField] Objects[] OpenObjects;
    [SerializeField] Objects[] CloseObjects;
    
    [System.Serializable] struct StartPosition {
        [SerializeField] string name;
        public Transform transform;
        public Vector3 startPosition;
    }

    [SerializeField] StartPosition[] startPositions;

    [System.Serializable] struct StartAngle {
        [SerializeField] string name;
        public Transform transform;
        public Vector3 startAngle;
    }
    [SerializeField] StartAngle[] StartAngles;

    [System.Serializable] struct StartScale {
        [SerializeField] string name;
        public Transform transform;
        public Vector3 startScale;
    }
    [SerializeField] StartScale[] StartScales;
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
            if(startPositions[i].transform != null)
            startPositions[i].transform.localPosition = startPositions[i].startPosition;
        }

        for(i = 0; i < StartAngles.Length; i++) {
            if(StartAngles[i].transform != null)
            StartAngles[i].transform.localEulerAngles = StartAngles[i].startAngle;
        }

        for(i = 0; i < StartScales.Length; i++) {
            if(StartScales[i].transform != null)
            StartScales[i].transform.localScale = StartScales[i].startScale;
        }
    }
}
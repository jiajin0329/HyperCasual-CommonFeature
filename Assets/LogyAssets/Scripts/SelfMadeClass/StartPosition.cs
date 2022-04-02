using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct StartPosition {
    [SerializeField] private string name;
    public Transform transform;
    public Vector3 startPosition;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanDraged : MonoBehaviour {
    public bool touched;
    [SerializeField] bool hasStartPosition;
    public Vector3 targetPosition;
    public Vector3 startPosition;
    [SerializeField] float smoothTime = 0.1f;
    Vector3 posVelocity;

    void Start() {
        startPosition = transform.position;
        targetPosition = startPosition;
    }

    void Update() {
        if(!touched && hasStartPosition) {
            transform.position = Vector3.SmoothDamp(transform.position, startPosition, ref posVelocity, smoothTime);
        }
        else {
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref posVelocity, smoothTime);
        }
    }
}

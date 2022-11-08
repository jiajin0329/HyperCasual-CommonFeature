using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Move {
    [SerializeField] Rigidbody rigidbody;

    public void MovePosition(Vector2 move_position) {
        rigidbody.position += new Vector3(move_position.x, 0f, move_position.y) * Time.deltaTime;
    }
}
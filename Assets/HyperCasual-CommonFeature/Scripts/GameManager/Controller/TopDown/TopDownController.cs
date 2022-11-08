using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownController : MonoBehaviour {
    [SerializeField] Vector2 move_local_position;
    [SerializeField] float speed;
    [SerializeField] float input_max_distance;
    [SerializeField] Character Character;
    [SerializeField] new Transform camera;
    
    MobileInput MobileInput;
    void Start() {
        MobileInput = MobileInput.Get();
        MobileInput.Get().TouchEvent.AddListener(MovePosition);
    }

    void MovePosition() {
        if(MobileInput.different_position == Vector2.zero)
            return;

        if(MobileInput.distance > input_max_distance) {
            move_local_position = InputToLocalMove(1f);
            Debug.Log("input distance max");
        }
        else {
            move_local_position = InputToLocalMove(MobileInput.distance / input_max_distance);
            Debug.Log("input");
        }

        Character.Move.MovePosition(move_local_position * speed);
    }

    Vector2 InputToLocalMove(float r) {

        return new Vector2(r * Mathf.Sin(camera.eulerAngles.y*Mathf.Deg2Rad + MobileInput.radian), r * Mathf.Cos(camera.eulerAngles.y*Mathf.Deg2Rad + MobileInput.radian));
    }
}

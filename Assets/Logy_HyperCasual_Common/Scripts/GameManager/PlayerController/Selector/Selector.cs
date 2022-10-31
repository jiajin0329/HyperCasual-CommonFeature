using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {
    //Singleton
    static Selector singleton;
    public static Selector Get() {return singleton;}
    static bool singletonization;
    Selector() {}

    [SerializeField] CanSelect canSelect;
    Ray ray;
    RaycastHit hit;
    public LayerMask layerMask;

    void Awake() {
        //Singleton
        if(!singletonization) {
            singletonization = true;
            singleton = this;
        }
    }

    void Update() {
        Select();
    }

    void Select() {
        if(MobileInput.Get().touchDown) {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit, 100f, layerMask)) {
                CanSelect temp_canSelect = hit.transform.GetComponent<CanSelect>();
                if(canSelect != null) {
                    if(canSelect != temp_canSelect) {
                        temp_canSelect.Select();
                        canSelect = temp_canSelect;
                    }
                    else
                        canSelect.Select();
                }
                else {
                    temp_canSelect.Select();
                    canSelect = temp_canSelect;
                }
                    
                Debug.Log("Hit");
            }

            //Debug.Log("TouchDown");
        }
    }
}

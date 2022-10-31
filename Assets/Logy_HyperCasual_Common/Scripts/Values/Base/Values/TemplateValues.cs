using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TemplateValues : MonoBehaviour, Values {
    public enum Type {hp, fp}
    [System.Serializable] public struct Value {
        public string name;
        public Type type;
        public ushort max;
        public ushort value;
    }
    [SerializeField] Value[] values;

    public void SetValuesName() {
        for(byte i = 0; i < values.Length; i++) {
            values[i].name = values[i].type.ToString();
        }
    }

    public float GetValue(int index) {return values[SearchValue(index)].value;}
    public void SetValue(int index, ushort set) {
        int searched_index = SearchValue(index);
        Value value = values[searched_index];
        if(set > value.max) value.value = value.max;
        else value.value = set;
    }
    
    int SearchValue(int index) {
        if(index != (int)values[index].type) {
            for(int i = 0; i < values.Length; i++) {
                if(index == (int)values[index].type) {
                    return i;
                }
            }
        }
        else {
            return index;
        }
        Debug.LogError("has same value");
        return 0;
    }

    void Start() {
        SetValuesName();
    }
}

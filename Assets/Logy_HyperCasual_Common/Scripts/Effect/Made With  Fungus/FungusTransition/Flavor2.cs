using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flavor2 : FungusTransition {
    [SerializeField] float angle;
    enum Type {type1, type2}
    [SerializeField] Type type;

    public override float CostTime() {return cost_time;}

    public void Init() {
        flowchart.GetVariable<Fungus.Vector3Variable>("angle").Value = new Vector3(0f, 0f, this.angle);

        if(type == Type.type2) {
            flowchart.SetFloatVariable("cost_time", cost_time / 2f);
            flowchart.SetFloatVariable("wait", cost_time / 4f);
        }
        else {
            flowchart.SetFloatVariable("cost_time", cost_time);
            flowchart.SetFloatVariable("wait", 0f);
        }
    }
}

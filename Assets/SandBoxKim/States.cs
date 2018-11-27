using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class States : MonoBehaviour {

    protected StateType _type;

    public abstract StateType Type { get; }

    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void OnRun();
}

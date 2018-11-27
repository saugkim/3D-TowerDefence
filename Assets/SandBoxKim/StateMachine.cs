using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {

    [SerializeField]
    List<States> states;

    StateType currerntState;

    static StateMachine _instance;
    public static StateMachine Instance
    {
        get
        {
            _instance = FindObjectOfType(typeof(StateMachine)) as StateMachine;
            if (!_instance)
            {
                Debug.LogError("State machine is not in your scene!");
            }
            return _instance;
        }
    }

    void Start()
    {
        if (states != null && states.Count > 0)
        {
            currerntState = states[0].Type;
            CurrentStateEnter();
        }
    }

    void Update()
    {
        CurrentStateRun();
    }

    void CurrentStateEnter()
    {
        if (states != null && states.Count > 0)
        {
            for (int i = 0; i < states.Count; i++)
            {
                if (states[i].Type == currerntState)
                {
                    states[i].OnEnter();
                    break;
                }
            }
        }
    }

    void CurrentStateRun()
    {
        if (states != null && states.Count > 0)
        {
            for (int i = 0; i < states.Count; i++)
            {
                if (states[i].Type == currerntState)
                {
                    states[i].OnRun();
                    break;
                }
            }
        }
    }

    void CurrentStateExit()
    {
        if (states != null && states.Count > 0)
        {
            for (int i = 0; i < states.Count; i++)
            {
                if (states[i].Type == currerntState)
                {
                    states[i].OnExit();
                    break;
                }
            }
        }
    }

    public void ChangeState(StateType state)
    {
        if (states != null && states.Count > 0)
        {
            for (int i = 0; i < states.Count; i++)
            {
                if (states[i].Type == state)
                {
                    CurrentStateExit();
                    currerntState = state;
                    CurrentStateEnter();
                    break;
                }
            }
        }
    }


   
}

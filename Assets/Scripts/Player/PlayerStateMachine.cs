using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    PlayerBase currentState;
    
    void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
            currentState.Enter();
    }

   
    void Update()
    {
        if (currentState != null)
            currentState.Update();

        Debug.Log(currentState);
    }

    protected virtual PlayerBase GetInitialState()
    {
        return null;
    }

    public void ChangeState(PlayerBase newState)
    {
        currentState.Exit();

        currentState = newState;
        newState.Enter();
    }

    //show the current state on screen
    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10f, 10f, 100f, 100f));
        string content = "Current State : " + currentState.name;
        GUILayout.Label($"<color='black'><size=20>{content}</size></color>");
        GUILayout.EndArea();
    }
}

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
        GUILayout.BeginArea(new Rect(10f, 10f, 200f, 100f));
        string content = currentState.name ;
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
        GUILayout.EndArea();
    }
}

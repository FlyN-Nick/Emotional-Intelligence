//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    [SerializeField] Text textComponent = null;
    [SerializeField] State startingState = null;

    State state;

	void Start()
    {
        state = startingState;
        textComponent.text = state.GetStateStory();
	}
	
	void Update()
    {
        if (!DetectQuit()) { ManageState(); }
    }

    private void ManageState()
    {
        var nextStates = state.GetNextStates();
        var stateChanged = false;
        for (int index = 0; index < nextStates.Count; index++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + index))
            {
                state = nextStates[index];
                stateChanged = true;
            }
        }
        if (stateChanged)
        {
            var stateStory = state.GetStateStory();
            if (stateStory != "")
                textComponent.text = state.GetStateStory();
        }
    }

    private bool DetectQuit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quit();
            return true;
        }
        else { return false; }
    }

    private void Quit() { Application.Quit(); }
}

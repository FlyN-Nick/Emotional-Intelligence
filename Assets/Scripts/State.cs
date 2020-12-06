using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{
    [TextArea(10, 14)] [SerializeField] string storyText = "";
    [SerializeField] List<State> nextStates = new List<State>();
    [SerializeField] bool quit = false;

    public string GetStateStory()
    {
        if (quit) { Application.Quit(); }
        return storyText;
    }

    public List<State> GetNextStates()
    {
        return nextStates;
    }
}

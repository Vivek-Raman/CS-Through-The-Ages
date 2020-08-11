using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : StateMachine
{
    [SerializeField] private List<ProcessorData> processors = null;

    public Transform pedestalFrame = null;
    public Transform infoPanel = null;

    [SerializeField] private TMP_Text debugStateText = null;
    [SerializeField] Button nextProcessorButton = null;

    private List<State> states = null;
    private int currentProcessorCounter = 0;

    private void Awake()
    {
        states = new List<State>();
        states.Add(new PedestalPlacementState(this));
        for (int i = 0; i < processors.Count; ++i)
        {
            states.Add(new PedestalExploreState(this, processors[i]));
        }

        initialState = states[0];
    }

    #region Button Event
    private void OnEnable()
    {
        nextProcessorButton.onClick.AddListener(OnNextClicked);
    }

    private void OnDisable()
    {
        nextProcessorButton.onClick.RemoveListener(OnNextClicked);
    }
    #endregion

    private void LateUpdate()
    {
        debugStateText.text = currentState.ToString();
    }

    public void PlaceNextProcessor()
    {
        ++currentProcessorCounter;
        SetState(states[currentProcessorCounter]);
    }

    private void OnNextClicked()
    {
        SetState(states[0]);
    }
}
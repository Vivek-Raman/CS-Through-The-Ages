using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIOptions : MonoBehaviour
{
    [SerializeField] private List<GameObject> optionsButtons = null;
    [SerializeField] private RectTransform informationPanel = null;
    
    
    private bool isOptionsButtonsActive = false;
    private bool isInformationPanelUp = false;

    private void Awake()
    {
        UI_SetInformationPanel(false);
    }

    public void UI_ToggleButtons()
    {
        UI_SetOptionsButtons(isOptionsButtonsActive.Toggle());
    }

    public void UI_SetOptionsButtons(bool enabled)
    {
        isOptionsButtonsActive = enabled;
        for (int i = 0; i < optionsButtons.Count; ++i)
        {
            optionsButtons[i].SetActive(isOptionsButtonsActive);
        }
    }

    public void UI_ToggleInformationPanel()
    {
        UI_SetInformationPanel(isInformationPanelUp.Toggle());
    }

    public void UI_SetInformationPanel(bool isUp)
    {
        isInformationPanelUp = isUp;
        if (isInformationPanelUp)
        {
            informationPanel.anchorMin = new Vector2(informationPanel.anchorMin.x, 0.25f);
            informationPanel.anchorMax = new Vector2(informationPanel.anchorMax.x, 0.75f);
        }
        else
        {
            informationPanel.anchorMin = new Vector2(informationPanel.anchorMin.x, -0.4f);
            informationPanel.anchorMax = new Vector2(informationPanel.anchorMax.x, 0.1f);
        }
    }

    public void UI_ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

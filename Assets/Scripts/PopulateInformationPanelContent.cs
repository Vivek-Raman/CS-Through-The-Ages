using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopulateInformationPanelContent : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text descriptionText;

    [SerializeField] private ProcessorData deleteThisVariable;

    private void Awake()
    {
        PopulateContent(deleteThisVariable);
    }

    public void PopulateContent(ProcessorData data)
    {
        titleText.text = data.title;
        descriptionText.text = data.description;
    }
}

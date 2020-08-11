using TMPro;
using UnityEngine;

public class PopulateInformationPanelContent : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text descriptionText;

    public void PopulateContent(ProcessorData data)
    {
        titleText.text = data.title;
        descriptionText.text = data.description;
    }
}

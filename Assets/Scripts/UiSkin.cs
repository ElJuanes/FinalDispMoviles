using UnityEngine;

public class CustomizationUIController : MonoBehaviour
{

    public GameObject customizationPanel;

    public void ToggleCustomizationPanel()
    {
        if (customizationPanel != null)
        {
            customizationPanel.SetActive(!customizationPanel.activeSelf);
        }
    }
}
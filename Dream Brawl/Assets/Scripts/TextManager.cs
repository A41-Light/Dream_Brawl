using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{

    public TMP_Text textComponent; // Reference to the TextMeshPro component
    
    public void UpdateText(string newText)
    {
        if (textComponent != null)
            textComponent.text = newText;
        else
            Debug.LogWarning("TMP Text Component is not assigned!");
    }

}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogController : MonoBehaviour
{
    [SerializeField] private GameObject dialogPanel;
    [SerializeField] private TMP_InputField urlInput;
    [SerializeField] private QRCodeGenerator qrGenerator;
    
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowDialog);
        
        if (dialogPanel != null)
            dialogPanel.SetActive(false);
    }

    void ShowDialog()
    {
        if (string.IsNullOrEmpty(urlInput.text))
        {
            Debug.LogWarning("Please enter a URL first");
            return;
        }

        if (dialogPanel != null)
        {
            dialogPanel.SetActive(true);
            qrGenerator.GenerateQRCode(urlInput.text);
        }
    }
}
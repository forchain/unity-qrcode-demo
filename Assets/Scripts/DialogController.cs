using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogController : MonoBehaviour
{
    [SerializeField] private TMP_InputField urlInput;
    [SerializeField] private QRCodeGenerator qrGenerator;
    
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ShowDialog);
        
    }

    void ShowDialog()
    {
        if (string.IsNullOrEmpty(urlInput.text))
        {
            Debug.LogWarning("Please enter a URL first");
            return;
        }

        qrGenerator.GenerateQRCode(urlInput.text);
    }
}
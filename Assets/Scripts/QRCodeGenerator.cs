using UnityEngine;
using UnityEngine.UI;
using ZXing;
using ZXing.QrCode;

public class QRCodeGenerator : MonoBehaviour
{
    private RawImage qrCodeImage;
    
    void Awake()
    {
        qrCodeImage = GetComponent<RawImage>();
    }

    public void GenerateQRCode(string url)
    {
        var encoded = new Texture2D(256, 256);
        var color32 = EncodeToQRCode(url, encoded.width, encoded.height);
        encoded.SetPixels32(color32);
        encoded.Apply();
        
        qrCodeImage.texture = encoded;
    }

    private static Color32[] EncodeToQRCode(string textForEncoding, int width, int height)
    {
        var writer = new BarcodeWriter
        {
            Format = BarcodeFormat.QR_CODE,
            Options = new QrCodeEncodingOptions
            {
                Height = height,
                Width = width,
                Margin = 1
            }
        };
        
        return writer.Write(textForEncoding);
    }
} 
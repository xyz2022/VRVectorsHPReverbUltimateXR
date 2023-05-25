using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhysicsText : MonoBehaviour
{
    //public TextMeshPro heightAboveOriginText;
    
    private void Start()
    {
        
    }

    public static void InitText(TextMeshProUGUI tmpro, string text, bool show, int fontSize)
    {
        TextSet(tmpro, text);
        TextShow(tmpro, show);
        TextFontSize(tmpro, fontSize);
    }
    public static void TextSet(TextMeshProUGUI tmpro, string text)
    {
        tmpro.text = text;
    }
    public static void TextPosition(TextMeshProUGUI tmpro, Vector3 position)
    {
        tmpro.transform.position = position;
    }
    public static void TextRotate(TextMeshProUGUI tmpro, Quaternion rotation)
    {
        tmpro.transform.rotation = rotation;//Quaternion.Euler(rotation.x, rotation.y, rotation.z);
    }
    public static void TextShow(TextMeshProUGUI tmpro, bool show)
    {
        tmpro.transform.gameObject.SetActive(show);
    }
    public static void TextFontSize(TextMeshProUGUI tmpro, int fontSize)
    {
        tmpro.fontSize = fontSize;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DynamicText : MonoBehaviour
{
    private Text text;
    void Start()
    {
        text = GetComponent<Text>();
    }
    public void UpdateText(int value)
    {
        text.text = value.ToString();
    }
    public void UpdateText(string value)
    {
        text.text = value;
    }

}

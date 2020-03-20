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
    public void UpdateText(int numero)
    {
        text.text = numero.ToString();
    }

}

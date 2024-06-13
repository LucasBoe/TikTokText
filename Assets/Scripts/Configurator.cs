using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Configurator : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] TMP_InputField textInputField;
    [SerializeField] TMP_InputField backgroundColorInputField;
    [SerializeField] TMP_InputField textColorInputField;
    [SerializeField] TMP_Dropdown fontSelection;
    [SerializeField] Toggle fontSelectionItemDummy;
    private bool isVisible = true;
    private void Start()
    {
        Main.Instance.OnIsAnimatingChangedEvent.AddListener(OnIsAnimatingChanged);

        var content = ContentHolder.Instance.Content;
        textInputField.text = content.Text.Value;
        fontSelection.AddOptions(FontProvider.Instance.Fonts.Select(f => f.name).ToList());
        content.Font.Change(0);

        textInputField.onValueChanged.AddListener(content.Text.Change);
        fontSelection.onValueChanged.AddListener(content.Font.Change);
        BindColorField(backgroundColorInputField, content.BackgroundColor);
        BindColorField(textColorInputField, content.TextColor);
    }

    private void BindColorField(TMP_InputField textField, NestedColor color)
    {
        textField.text = ColorUtility.ToHtmlStringRGB(Color.green);
        textField.onValueChanged.AddListener((c) =>
        {
            textField.GetComponentInChildren<Image>().color = color.Change(c);
            ;
        });
    }

    private void OnIsAnimatingChanged(bool isAnimating) => SetVisible(!isAnimating);
    private void SetVisible(bool visible)
    {
        isVisible = visible;
        canvas.enabled = visible;
    }
}

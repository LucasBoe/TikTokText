using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Configurator : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] TMP_InputField inputField;
    [SerializeField] TMP_Dropdown fontSelection;
    [SerializeField] Toggle fontSelectionItemDummy;

    private bool isVisible = true;

    private void OnEnable()
    {
        inputField.onValueChanged.AddListener(UpdateText);
        fontSelection.onValueChanged.AddListener(TrySelectFont);
    }
    private void OnDisable()
    {
        inputField.onValueChanged.RemoveListener(UpdateText);
        fontSelection.onValueChanged.RemoveListener(TrySelectFont);
    }
    private void Start()
    {
        fontSelection.AddOptions(FontProvider.Instance.Fonts.Select(f => f.name).ToList());
        TrySelectFont(0);
    }
    private void TrySelectFont(int index)
    {
        ContentHolder.Instance.Content.Font.Value = FontProvider.Instance.Fonts[index];
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            SetVisible(!isVisible);
    }
    private void UpdateText(string text) => ContentHolder.Instance.Content.Text.Value = text;
    private void SetVisible(bool visible)
    {
        isVisible = visible;
        canvas.enabled = visible;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBackgroundColorBinder : MonoBehaviour
{
    [SerializeField] new Camera camera;
    private void Start()
    {
        ContentHolder.Instance.Content.BackgroundColor.OnValueChangedEvent.AddListener(OnBackgroundColorChanged);
    }
    private void OnBackgroundColorChanged(Color backgroundColor) => camera.backgroundColor = backgroundColor;
}

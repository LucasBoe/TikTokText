using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Main : Singleton<Main>
{
    private bool isAnimating = false;
    public UnityEvent<bool> OnIsAnimatingChangedEvent;
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
            SetAnimating(!isAnimating);
    }
    private void SetAnimating(bool _isAnimating)
    {
        this.isAnimating = _isAnimating;
        OnIsAnimatingChangedEvent?.Invoke(isAnimating);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ContentHolder : Singleton<ContentHolder>
{
    public Content Content = new();
}
[System.Serializable]
public class Content
{
    public NestedString Text;
    public NestedFont Font;
    public NestedColor BackgroundColor;
    public NestedColor TextColor;
}

[System.Serializable]
public class NestedColor : Nested<Color>
{
    public Color Change(string hex)
    {
        if (!ColorUtility.TryParseHtmlString(hex, out Color color))
            return Color.white;

        Change(color);
        return color;
    }
}
[System.Serializable]
public class NestedFont : Nested<TMP_FontAsset>
{
    public void Change(int index)
    {
        Change(FontProvider.Instance.Fonts[index]);
    }
}
[System.Serializable] public class NestedString : Nested<string> { }

[System.Serializable]
public class Nested<T>
{
    [SerializeField] private T value;
    public T Value
    {
        get
        {
            return value;
        }
        set
        {
            var before = this.value;
            this.value = value;

            if (!EqualityComparer<T>.Default.Equals(before, this.value))
                OnValueChangedEvent?.Invoke(this.value);
        }
    }
    public void Change(T value)
    {
        Value = value;
    }
    public UnityEvent<T> OnValueChangedEvent = new();
}
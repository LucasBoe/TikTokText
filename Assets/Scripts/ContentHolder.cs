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
}

[System.Serializable] public class NestedFont : Nested<TMP_FontAsset> { }
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

    UnityEvent<T> OnValueChangedEvent;
}
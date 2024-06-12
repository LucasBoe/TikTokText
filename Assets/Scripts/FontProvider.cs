using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FontProvider : Singleton<FontProvider>
{
    public List<TMP_FontAsset> Fonts { get; private set; } = new();
    protected override void Awake()
    {
        base.Awake();

        foreach (TMP_FontAsset font in Resources.LoadAll("Fonts", typeof(TMP_FontAsset)))
        {
            Fonts.Add(font);
        }
    }
}

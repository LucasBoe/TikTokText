using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnimator : MonoBehaviour
{
    [SerializeField] LineView lineDummy;
    private void Start()
    {
        lineDummy.gameObject.SetActive(false);
    }
    public void Animate(Content content)
    {
        Queue<LineView> lines = new();

        foreach (var line in Split(content.Text.Value))
        {
            var instance = Instantiate(lineDummy, lineDummy.transform.parent);
            instance.gameObject.SetActive(true);
            instance.Init(line, content);
            lines.Enqueue(instance);
        }

        StartCoroutine(AnimationRoutine(lines));
    }

    private static string[] Split(string text)
    {
        return text.Split('\n', '.');
    }

    private IEnumerator AnimationRoutine(Queue<LineView> lines)
    {
        while (lines.Count > 0)
        {
            var activeLine = lines.Dequeue();

            while (activeLine.TryAnimate())
            {
                while (!InputHandler.CheckAnyInput())
                    yield return null;

                yield return new WaitForSeconds(.05f);
            }
        }
    }
}
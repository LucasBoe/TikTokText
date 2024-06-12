using System;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

    public class TextAnimator : MonoBehaviour
    {
        [SerializeField] LineView lineDummy;
        [SerializeField, TextArea] string text;

        private bool initiated = false;
        private bool show = false;

        private void Start()
        {
            lineDummy.gameObject.SetActive(false);
        }
        [Button] private void Test()
        {
            Animate(text);
        }
        public void Animate(string text)
        {
            if (initiated)
                return;

            initiated = true;

            Queue<LineView> lines = new();

            foreach (var line in Split(text))
            {
                var instance = Instantiate(lineDummy, lineDummy.transform.parent);
                instance.gameObject.SetActive(true);
                instance.Init(line);
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
                    while (!show)
                        yield return null;
                    
                    show = false;
                }
            }
        }
        private void OnGUI()
        {
            if (GUILayout.Button("Next\nnn"))
            {
                show = true;


                Test();
            }
        }
    }

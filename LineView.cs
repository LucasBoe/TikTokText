using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

    public class LineView : MonoBehaviour
    {
        [SerializeField] CanvasGroup canvasGroup;
        [SerializeField] TMP_Text textDummy;

        Queue<TMP_Text> words = new();

        internal void Init(string line)
        {
            foreach (var word in line.Split(' '))
            {
                var instance = Instantiate(textDummy, textDummy.transform.parent);
                instance.text = word;
                instance.transform.localScale = Vector3.zero;
                words.Enqueue(instance);
            }

            canvasGroup.alpha = 0;
            textDummy.gameObject.SetActive(false);
        }

        internal bool TryAnimate()
        {
            if (words.Count <= 0)
            {
                var _out = DOTween.Sequence();

                _out.Append(canvasGroup.transform.DOLocalMoveY(-500, .1f).SetEase(Ease.InBack));
                _out.AppendCallback(() => canvasGroup.alpha = 0);
                return false;
            }

            var active = words.Dequeue();

            active.transform.rotation = Quaternion.Euler(0,0,45f);

            active.transform.DORotate(new Vector3(0,0,4), .3f).SetEase(Ease.OutBack);
            active.transform.DOScaleX(1.2f, .2f).SetEase(Ease.OutBack);
            active.transform.DOScaleY(1.2f, .3f).SetEase(Ease.OutBounce);

            active.transform.DOScale(1, .25f).SetEase(Ease.OutSine).SetDelay(.5f);
            active.transform.DORotate(Vector3.zero, .15f).SetEase(Ease.InOutSine).SetDelay(.5f);

            canvasGroup.alpha = 1;
            return true;
        }
    }

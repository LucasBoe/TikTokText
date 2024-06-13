using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : Singleton<AnimationHandler>
{
    [SerializeField] TextAnimator viewDummy;
    private TextAnimator current;
    protected override void Awake()
    {
        base.Awake();
        viewDummy.gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        Main.Instance.OnIsAnimatingChangedEvent.AddListener(OnIsAnimatingChanged);
    }
    private void OnDisable()
    {
        Main.Instance.OnIsAnimatingChangedEvent.RemoveListener(OnIsAnimatingChanged);
    }
    private void OnIsAnimatingChanged(bool animate)
    {
        if (animate)
            Animate();
        else
            Clear();
    }
    public void Clear()
    {
        if (current != null)
            Destroy(current.gameObject);
    }
    public void Animate()
    {
        Clear();

        current = Instantiate(viewDummy, viewDummy.transform.parent);
        current.gameObject.SetActive(true);
        current.Animate(ContentHolder.Instance.Content);
    }
}
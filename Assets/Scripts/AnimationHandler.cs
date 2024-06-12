using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : Singleton<AnimationHandler>
{
    [SerializeField] AnimationView viewDummy;
    private AnimationView current;
    protected override void Awake()
    {
        base.Awake();
        viewDummy.gameObject.SetActive(false);
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

    }
}
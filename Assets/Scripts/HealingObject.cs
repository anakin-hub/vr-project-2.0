using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingObject : SliceableObject
{
    public override void OnCut()
    {
        base.OnCut();
        manager.Heal();
    }

    public override void OnFall()
    {
        Destroy(gameObject);
        Debug.Log("heal");
    }
}

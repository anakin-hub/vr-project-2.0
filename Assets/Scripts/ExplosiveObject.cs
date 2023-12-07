using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveObject : SliceableObject
{
    public override void OnCut()
    {
        manager.MissTarget();
    }

    public override void OnFall()
    {
        Destroy(gameObject);
        Debug.Log("heal");
    }
}

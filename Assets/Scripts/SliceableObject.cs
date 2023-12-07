using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SliceableObject : MonoBehaviour
{
    public Manager manager;
    public Transform startPoint;
    public Transform endPoint;
    public Rigidbody rb;

    public void SetUp(Manager manager, Vector3 direction, float launchForce)
    {
        this.manager = manager;
        rb.AddForce(direction * launchForce);
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Destroyer"))
        {
            OnFall();
        }
    }

    public virtual void OnCut()
    {
        manager.AddPoints();
    }

    public virtual void OnFall()
    {
        manager.MissTarget();
        Destroy(gameObject);
        Debug.Log("ball");
    }
}

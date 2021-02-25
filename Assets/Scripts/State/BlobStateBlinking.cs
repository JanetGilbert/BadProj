using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobStateBlinking : BlobState
{
    private Renderer renderer; // cached

    // blink management
    private float blinkDelay = 0.5f;
    private float blinkTimer = 0.0f;
    private bool visible = true;

    // Time until state change
    private const float minTime = 1.0f;
    private const float maxTime = 5.0f;
    private float elapsedTime;
    private float endTime;


    // Derived class constructor calls base class constructor.
    public BlobStateBlinking (Blob theBlob) : base(theBlob) { }

    public override void Run() 
    {
        elapsedTime += Time.deltaTime;
        blinkTimer += Time.deltaTime;

        if (blinkTimer > blinkDelay) {
            visible = !visible;
            renderer.enabled = visible;
        }

        if (elapsedTime > endTime) blob.ChangeState(new BlobStateMoving(blob));
    }

    public override void Enter()
    {
        base.Enter();

        renderer = blob.GetComponent<Renderer>();
        endTime = Random.Range(minTime, maxTime);
    }

    public override void Leave()
    {
        renderer.enabled = true;
        blob.SetScore(1);
    }
}
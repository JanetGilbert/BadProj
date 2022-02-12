using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* This state class is derived from BlobState.
 * In this state, the blob moves in a sine wave pattern.*/
public class BlobStateMoving : BlobState
{

    // Movement over time.
    private Vector3 curPos;
    private float elapsedTime;
    private float endTime;
    private Vector3 direction;

    public BlobStateMoving(Blob theBlob) : base(theBlob) // Derived class constructor calls base class constructor.
    {

    }

    public override void Run() // Overriden from base class.
    {
        // Regular movement
        curPos += Time.deltaTime * direction; 

        // Sine movement
        elapsedTime += Time.deltaTime;
        Vector3 offset = new Vector3(0.0f, blob.amplitude * Mathf.Sin(elapsedTime * blob.sinSpeed), 0.0f);
        blob.transform.position = curPos + offset;

        if (elapsedTime > endTime)
        {
            blob.ChangeState(new BlobStatePulsing(blob)); // Change to color pulsing state.
        }
    }

    public override void Enter() // Overriden from base class.
    {
        base.Enter(); // Call base class.

        curPos = blob.transform.position;
        endTime = Random.Range(blob.minTime, blob.maxTime);
        direction = new Vector3(Random.Range(-1.0f, 1.0f), 0.0f, Random.Range(-1.0f, 1.0f)); // Move in random direction.
    }
}

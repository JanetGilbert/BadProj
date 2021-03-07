using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlobStateBlinking : BlobState
{
    //public Renderer rend;

    private float elapsedTime = 0f;
    private float endTime = 0.5f;
   
    public BlobStateBlinking(Blob theBlob) : base(theBlob) // Derived class constructor calls base class constructor.
    {

    }

    public override void Run() // Overriden from base class.
    {
        /*elapsedTime += Time.deltaTime;

        if (elapsedTime > endTime)
        {
            renderer.enabled = false;
        }*/

        /*if (elapsedTime > endTime + 1f/Time.deltaTime){
                renderer.enabled = true;

                elapsedTime = 0;

        }*/
              

    }

    public override void Enter() // Overriden from base class.
    {
        base.Enter(); // Call base class.

        //rend = GetComponent<Renderer>();

    }

    public override void Leave(){
        blob.addPoint();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasePlatformPower : Powers
{
    private void FixedUpdate()
    {
        transform.position -= new Vector3(0, 0.05f, 0);
    }

    public override void ImplementPower(GameObject gameObjectPowerImplementsTo)
    {
        //Debug.Log("IncreasePlatformPower implementPower");
        gameObjectPowerImplementsTo.transform.localScale += new Vector3(1.0f, 0, 0);
    }
}
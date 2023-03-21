using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasePlatformPower : Powers
{
    public override void ImplementPower(GameObject gameObjectPowerImplementsTo)
    {
        //Debug.Log("IncreasePlatformPower implementPower");
        gameObjectPowerImplementsTo.transform.localScale += new Vector3(1.0f, 0, 0);
    }
}
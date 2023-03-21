using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerTypes
{
    increasePlatformSize,
    multiplyBalls
}

public abstract class Powers : MonoBehaviour
{
    [SerializeField] private PowerTypes _powerType;
    private float _constantSpeed = 5.0f;
    public PowerTypes Type => _powerType;

    private void FixedUpdate()
    {
        transform.position += _constantSpeed * Vector3.down * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Powers onTriggerEnter2D " + collision.gameObject.name);

        if (collision.gameObject.name == "Platform")
        {
            ImplementPower(collision.gameObject);
            Destroy(gameObject);
        }
    }

    public abstract void ImplementPower(GameObject gameObjectPowerImplementsTo);
}

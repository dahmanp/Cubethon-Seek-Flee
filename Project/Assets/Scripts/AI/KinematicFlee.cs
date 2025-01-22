using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicFlee : MonoBehaviour
{
    public Transform character;
    public Transform target;

    public float maxSpeed;

    void Update()
    {
        getSteering();
    }

    private float newOrientation(float current, Vector3 velocity)
    {
        if (velocity.magnitude > 0)
        {
            return (Mathf.Atan2(velocity.x, velocity.z) * Mathf.Rad2Deg);
        }
        else
        {
            return current;
        }
    }

    public KinematicSteeringOutput getSteering()
    {
        KinematicSteeringOutput result = new KinematicSteeringOutput();

        result.velocity = character.position - target.position;

        result.velocity.Normalize();
        result.velocity *= maxSpeed;

        float angle = newOrientation(character.rotation.eulerAngles.y, result.velocity);
        character.eulerAngles = new Vector3(0, angle, 0);

        character.position += result.velocity * Time.deltaTime;

        result.rotation = 0;
        return result;
    }
}
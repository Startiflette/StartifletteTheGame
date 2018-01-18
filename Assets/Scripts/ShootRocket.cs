using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRocket : MonoBehaviour
{
    //Drag in the Bullet Emitter from the Component Inspector.
    public GameObject Bullet_Emitter;
    //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject Bullet;
    //Rocket speed
    public float smoothSpeed = 50f;

    // Update is called once per frame
    void Update()
    {
        // On pressed left click
        if (Input.GetMouseButtonDown(0))
        {
            //The Bullet instantiation happens here.
            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;

            // Sometimes bullets may appear rotated incorrectly due to the way its pivot was set from the original modeling package.
            // This is EASILY corrected here, you might have to rotate it from a different axis and or angle based on your particular mesh.
            // Temporary_Bullet_Handler.transform.Rotate(Vector3.left * 90);

            // Retrieve the Rigidbody component from the instantiated Bullet and control it.
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();

            IEnumerator coroutine = Follow(Temporary_Bullet_Handler, Camera.main.GetComponent<Camera>().transform.position);
            StartCoroutine(coroutine);

            //Temporary_RigidBody.AddForce(transform.forward * Bullet_Forward_Force);
        }
    }

    IEnumerator Follow(GameObject rocket, Vector3 desiredPos)
    {
        bool toDestroy = false;
        while (!toDestroy) {
            
            if (rocket == null)
            {
                toDestroy = true;
            }
            else
            {
                rocket.transform.position = Vector3.MoveTowards(rocket.transform.position, desiredPos, smoothSpeed * Time.deltaTime);
            }

            yield return null;
        }

        if(rocket == null)
        {
            Destroy(rocket);
        }
        yield return null;
    }

}

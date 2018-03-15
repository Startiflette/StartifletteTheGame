using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRocket : MonoBehaviour
{
    //Drag in the Bullet Emitter from the Component Inspector.
    public GameObject bulletEmitter;
    //Drag in the Bullet Prefab from the Component Inspector.
    public GameObject bullet;
    //Rocket speed
    public float smoothSpeed = 50f;
    public float smoothSpeedRotate = 50f;
    public float missileVelocity = 1f;
    public float shootRange = 5f;

    private int numberMisileShooted = 0;
    private float dist;
    private GameObject player;


    void Start()
    {
        StartCoroutine("Shoot");
    }

    IEnumerator Follow(GameObject rocket, GameObject target)
    {
        bool toDestroy = false;
        while (!toDestroy) {
            Vector3 desiredPos = target.transform.position;


            if (rocket == null)
            {
                toDestroy = true;
            }
            else
            {
                // Desired rotation
                Vector3 lookAt = desiredPos - rocket.transform.position;
                Quaternion targetRotation = rocket.transform.rotation;
                if (lookAt.Equals(Vector3.zero)) { 
                    targetRotation = Quaternion.LookRotation(lookAt);
                }
                // Smoothly rotate towards the target point.
                Rigidbody rocketRigidbody = rocket.GetComponent<Rigidbody>();
                rocketRigidbody.MoveRotation(Quaternion.RotateTowards(rocket.transform.rotation, targetRotation, smoothSpeed));

                rocketRigidbody.velocity = rocket.transform.forward * missileVelocity;

                targetRotation = Quaternion.LookRotation(desiredPos - rocket.transform.position);

                rocketRigidbody.MoveRotation(Quaternion.RotateTowards(rocket.transform.rotation, targetRotation, smoothSpeedRotate));
            }

            yield return null;
        }

        if(rocket == null)
        {
            Destroy(rocket);
        }
        yield return null;
    }

    IEnumerator Shoot()
    {
        while (gameObject.activeSelf)
        {
            player = GameObject.FindGameObjectWithTag("ship");
            dist = Vector3.Distance(player.transform.position, bulletEmitter.transform.position);
            if (dist < shootRange)
            {
                //The Bullet instantiation happens here.
                GameObject temporaryBulletHandler;
				temporaryBulletHandler = (GameObject) Instantiate(bullet, bulletEmitter.transform.position, bulletEmitter.transform.rotation);

                IEnumerator coroutine = Follow(temporaryBulletHandler, player);
                StartCoroutine(coroutine);
                numberMisileShooted++;

                if (numberMisileShooted < 2)
                {
                    yield return new WaitForSeconds(1);
                }
                else
                {
                    numberMisileShooted = 0;
                    yield return new WaitForSeconds(2);
                }
            } else
            {
                yield return new WaitForSeconds(2);
            }
        }
        yield return new WaitForSeconds(2);
    }

}

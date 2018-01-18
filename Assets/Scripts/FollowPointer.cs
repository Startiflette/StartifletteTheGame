using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPointer : MonoBehaviour {
    public GameObject pointeur;
    public float smoothSpeed = 6f;
    public float projectionZ;
    public float distanceMin;

    public float RotationSpeed;

    //values for internal use
    private Quaternion _lookRotation;
    private Vector3 _direction;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        //distance = Screen.height * 0.5f / Mathf.Tan(60 * 0.5f * Mathf.Deg2Rad);
        Camera c = Camera.main;
        Vector3 desiredPos = c.ScreenToWorldPoint(new Vector3(pointeur.transform.position.x, pointeur.transform.position.y, c.nearClipPlane +6f));
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPos;
        _direction = (desiredPos - transform.position).normalized;
        var dist = Vector3.Distance(desiredPos, transform.position);

        Debug.Log(dist);
        if (dist < distanceMin)
        {
            Debug.Log("Culay");
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, Time.deltaTime * RotationSpeed);
        }
        else
        {
            _lookRotation = Quaternion.LookRotation(_direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);
        }
        

        //Debug.Log("desiredPos : " + desiredPos + " pointeur : " + pointeur.transform.position + " posActuel : " + transform.position);
        //Debug.Log("smoothedPos : " + smoothedPos + "_direction : " + _direction);






        //Debug.Log(desiredPos);

        //transform.LookAt(new Vector2(pointeur.transform.position.x, pointeur.transform.position.y));



        //Vector3 canvasToWorldPos = Camera.main.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(pointeur.transform.position.x, pointeur.transform.position.y, 0f));

        //Vector3 desiredPos = new Vector3(canvasToWorldPos.x, canvasToWorldPos.y, transform.position.z);
        //Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
        //Debug.Log(transform.position + " / " + smoothedPos + " / " + canvasToWorldPos + " / " + distance);
        //transform.position = smoothedPos;

        ////Vector3 desiredPos = pointeur.transform.position.;

        //transform.LookAt(desiredPos + new Vector3(0, 0, projectionZ));


    }

    Vector3 ProjectPointOnPlane( Vector3 planeNormal, Vector3 planePoint , Vector3 point )
    {
     
     var dist = Vector3.Dot(planeNormal, (point - planePoint));
     return point + planeNormal.normalized* -dist;
 }   
}


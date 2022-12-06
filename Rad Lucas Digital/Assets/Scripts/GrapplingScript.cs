using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingScript : MonoBehaviour
{
    [Header("Input")]
    public KeyCode swingKey = KeyCode.Mouse0;

    [Header("References")]
    public Transform hook;
    public Transform player;
    public Transform cam;
    public LayerMask whatIsGround; //everything is grappleable: for now XD
    public LineRenderer lr;
    public PlayerMovementModified pm;


    [Header("Swinging")]
    private float maxDistance = 25f; //swing distance limitation
    private Vector3 swingSpot;
    private SpringJoint joint;

    [Header("NOT_AOT_OdmGear")]
    public Transform orientation;
    public Rigidbody rb;
    public float horizontalPushForce;
    public float forwardPushForce;
    public float extendCableSpeed;

    [Header("Prediction")]
    public RaycastHit predictionHit;
    public float predictionSphereCastRadius;
    public Transform predictionPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(swingKey)) StartSwing();
        if (Input.GetKeyUp(swingKey)) StopSwing();

        CheckForSwingSpot();

        if (joint != null) NOT_AttackOnTitanOdmGearMovementHeadass();
    }

    void LateUpdate()
    {
        DrawRope();
    }

    private void StartSwing()
    {
        // do nothing if prediction is not found
        if (predictionHit.point == Vector3.zero) return;

        // deactivate grappling hook if it is still grappling
        if(GetComponent<Grappling>() != null)
            GetComponent<Grappling>().StopGrapple();
        pm.ResetRestrictions();


        pm.swinging = true;

        
        swingSpot = predictionHit.point;
        joint = player.gameObject.AddComponent<SpringJoint>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedAnchor = swingSpot;

        float distanceFromPoint = Vector3.Distance(player.position, swingSpot);

        // grappler will try to keep this distance from the point it grapples onto
        joint.maxDistance = distanceFromPoint * 0.8f;
        joint.minDistance = distanceFromPoint * 0.25f;

        // change value if needed after testing
        joint.spring = 4.5f;
        joint.damper = 7f;
        joint.massScale = 4.5f;

        lr.positionCount = 2;
        currentGrapplePosition = hook.position;
        
    }

    private Vector3 currentGrapplePosition;

    void DrawRope()
    {
        if (!joint) return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, swingSpot, Time.deltaTime * 8f);

        lr.SetPosition(0, hook.position);
        lr.SetPosition(1, swingSpot);
    }

    public void StopSwing()
    { 
        pm.swinging = false;        
        lr.positionCount = 0;
        Destroy(joint);
    }

    //aka air control
    private void NOT_AttackOnTitanOdmGearMovementHeadass()
    {
        // right
        if (Input.GetKey(KeyCode.D)) rb.AddForce(orientation.right * horizontalPushForce * Time.deltaTime);
        // left
        if (Input.GetKey(KeyCode.A)) rb.AddForce(-orientation.right * horizontalPushForce * Time.deltaTime);

        // forward
        if (Input.GetKey(KeyCode.W)) rb.AddForce(orientation.forward * forwardPushForce * Time.deltaTime);

        // shorten cable
        if(Input.GetKey(KeyCode.Space))
        {
            Vector3 directionToPoint = swingSpot - transform.position;
            rb.AddForce(directionToPoint.normalized * forwardPushForce * Time.deltaTime);

            float distanceFromPoint = Vector3.Distance(transform.position, swingSpot);

            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;
        }

        // cable extendo
        if (Input.GetKey(KeyCode.S))
        {
            float extendedDistanceFromPoint = Vector3.Distance(transform.position, swingSpot) + extendCableSpeed;

            joint.maxDistance = extendedDistanceFromPoint * 0.8f;
            joint.minDistance = extendedDistanceFromPoint * 0.25f;
        }
    }

    // hit prediction
    private void CheckForSwingSpot()
    {
        if (joint != null) return;

        RaycastHit sphereCastHit;
        Physics.SphereCast(cam.position, predictionSphereCastRadius, cam.forward, out sphereCastHit, maxDistance, whatIsGround);

        RaycastHit raycastHit;
        Physics.Raycast(cam.position, cam.forward, out raycastHit, maxDistance, whatIsGround);

        Vector3 realHitPoint;

        // direct hit
        if (raycastHit.point != Vector3.zero) realHitPoint = raycastHit.point;
        // indirect hit (in prediction area)
        else if (sphereCastHit.point != Vector3.zero) realHitPoint = sphereCastHit.point;
        // miss
        else realHitPoint = Vector3.zero;

        // realHitPoint found
        if(realHitPoint != Vector3.zero)
        {
            predictionPoint.gameObject.SetActive(true);
            predictionPoint.position = realHitPoint;
        }
        // not found
        else
        {
            predictionPoint.gameObject.SetActive(false);
        }

        predictionHit = raycastHit.point == Vector3.zero ? sphereCastHit : raycastHit;
    }
}

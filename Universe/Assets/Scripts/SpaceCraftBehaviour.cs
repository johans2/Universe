using UnityEngine;
using System.Collections;
using Universe.Core.DependencyInjection;
using Universe.Game;


public class SpaceCraftBehaviour : MonoBehaviour 
{
    [Dependency] public ISpaceCraft spaceCraft;
    [Dependency] public IZoneManager zoneManager { get; private set; }

    public float MoveSpeed = 0.1f;
    public float Deceleration = 0.06f;
    
    private bool move;
    private bool decelerate;
    private Vector3 targetPosition;
    private Vector3 targetDirection;
    private float targetHitBuffer = 0.1f;

    private enum PlaneState 
    { 
        Stop,
        Move,
        Decelerate
    }

	void Start () {
        this.Inject();
        this.move = false;
        this.decelerate = false;

        spaceCraft.EnterZone += zoneManager.OnEnterZone;
	}
	
	void Update () {
        spaceCraft.TransformPosition = new Vector2(transform.position.x, transform.position.z);

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(new Vector3(0, 0, 0), hit.point, Color.red, 20);
            }

            targetPosition = hit.point;
            targetDirection = new Vector3(targetPosition.x - transform.position.x, 0, targetPosition.z - transform.position.z).normalized; 

            Debug.DrawLine(targetPosition, transform.position, Color.blue, 3);

            move = true;
        }

        if (move)
        {
            transform.position += targetDirection * MoveSpeed;
            if (   targetPosition.x - targetHitBuffer < transform.position.x 
                && targetPosition.x + targetHitBuffer > transform.position.x  
                && targetPosition.z - targetHitBuffer < transform.position.z
                && targetPosition.z + targetHitBuffer > transform.position.z
            )
            {
                move = false;
                decelerate = true;
            }
        }

        if (decelerate)
        {
            float decelerationSpeed = MoveSpeed - Deceleration;
            transform.position += targetDirection * (decelerationSpeed);
            Deceleration += 0.001f;

            if (decelerationSpeed < 0)
            {
                decelerate = false;
                Deceleration = 0.06f;
            }
        }
	}
}

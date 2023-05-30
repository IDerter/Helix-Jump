using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BallMovement))]
public class BallController : OneColliderTrigger
{
    private BallMovement ballMovement;

    [HideInInspector] public UnityEvent<SegmentType> CollisionSegment;
    [SerializeField] private int countEmptySegment;
    public int CountEmptySegment => countEmptySegment;

    private void Start()
    {
        ballMovement = GetComponent<BallMovement>();
    }

    protected override void OnOneTriggerEnter(Collider other)
    {
        Segment segment = other.GetComponent<Segment>();
        Debug.Log(segment.name.ToString());
        Floor floor = other.GetComponentInParent<Floor>();
        if(segment != null)
        {
            if (segment.Type == SegmentType.Empty)
            {
                ballMovement.Fall(other.transform.position.y);
                Debug.Log(segment.name.ToString() + "!");
                other.GetComponentInParent<Rigidbody>().isKinematic = false;
                other.GetComponentInParent<Animator>().enabled = true;
                floor.SetUnvisibleColliderAllSegment();
                countEmptySegment++;
            }

            if (segment.Type == SegmentType.Default)
            {
                Debug.Log("Jump");
                Debug.Log(segment.name.ToString() + "!!");
                ballMovement.Jump();
                countEmptySegment = 0;
            }

            if(segment.Type == SegmentType.Finish || segment.Type == SegmentType.Trap)
            {
                ballMovement.Stop();
                countEmptySegment = 0;
            }
        }

        
        CollisionSegment.Invoke(segment.Type);
    }

}

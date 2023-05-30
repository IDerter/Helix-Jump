using UnityEngine;

public abstract class BallEvents : MonoBehaviour
{
    [SerializeField] protected BallController ballController;

    protected virtual void Awake()
    {
        ballController.CollisionSegment.AddListener(OnBallColissionSegment); // подписываемся на событие CollisionSegment
    }

    protected virtual void OnDestroy()
    {
        ballController.CollisionSegment.RemoveListener(OnBallColissionSegment); // отписываемся от события CollisionSegment
    }

    protected virtual void OnBallColissionSegment(SegmentType type) { } // подписчик события
    
}

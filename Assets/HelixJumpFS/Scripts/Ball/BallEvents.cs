using UnityEngine;

public abstract class BallEvents : MonoBehaviour
{
    [SerializeField] protected BallController ballController;

    protected virtual void Awake()
    {
        ballController.CollisionSegment.AddListener(OnBallColissionSegment); // ������������� �� ������� CollisionSegment
    }

    protected virtual void OnDestroy()
    {
        ballController.CollisionSegment.RemoveListener(OnBallColissionSegment); // ������������ �� ������� CollisionSegment
    }

    protected virtual void OnBallColissionSegment(SegmentType type) { } // ��������� �������
    
}

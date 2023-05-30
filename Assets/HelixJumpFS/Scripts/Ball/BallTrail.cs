using UnityEngine;

public class BallTrail : BallEvents
{
    [SerializeField] private Transform parentTransform;
    [SerializeField] private MeshRenderer visualMeshRenderer;
    [SerializeField] private Blot blotPrefab;


    protected override void OnBallColissionSegment(SegmentType type)
    {
        if (type != SegmentType.Empty)
        {
            Blot blot = Instantiate(blotPrefab, parentTransform);
            Color color = visualMeshRenderer.material.color;
            color.a = 1;
            blot.Init(new Vector3(visualMeshRenderer.transform.position.x, transform.position.y, visualMeshRenderer.transform.position.z), color);
        }
    }
}

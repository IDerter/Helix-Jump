using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : BallEvents
{
    [SerializeField] MouseRotator mouseRotator;

    protected override void OnBallColissionSegment(SegmentType type)
    {
        if (type == SegmentType.Finish || type == SegmentType.Trap)
        {
            mouseRotator.enabled = false;
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] private List<Segment> defaultSegments;
    [SerializeField] private List<Segment> allSegments;

    public void AddEmptySegment(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            defaultSegments[i].SetEmpty();
        }
        for (int i = amount; i >= 0; i--)
        {
            defaultSegments.RemoveAt(i);
        }
    }

    public void AddRandomTrapSegment(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            int index = Random.Range(0, defaultSegments.Count);

            defaultSegments[index].SetTrap();
            defaultSegments.RemoveAt(index);
        }
    }

    public void SetRandomRotationSegment()
    {
        transform.localEulerAngles = new Vector3(0, Random.Range(0, 360), 0);
    }

    public void SetFinishAllSegment()
    {
        for (int i = 0; i < defaultSegments.Count; i++)
        {
            defaultSegments[i].SetFinish();
        }
    }

    public void SetUnvisibleColliderAllSegment()
    {
        for (int i = 0; i < allSegments.Count; i++)
        {
            allSegments[i].GetComponent<MeshCollider>().enabled = false;
            Debug.Log(allSegments.ToString());
        }
    }

    public void SetActiveAllSegment()
    {
        for (int i = 0; i < allSegments.Count; i++)
        {
            allSegments[i].enabled = false;
        }
    }

}

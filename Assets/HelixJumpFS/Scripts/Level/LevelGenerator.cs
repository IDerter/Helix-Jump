using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform axis;
    [SerializeField] private Floor floorPrefab;

    [Header("Settings")]
    [SerializeField] private int defaultFloorAmount;
    [SerializeField] private float floorHeight;
    [SerializeField] private int emptySegmentAmount;
    [SerializeField] private int randomMinRange;
    [SerializeField] private int randomMaxRange;

    private float floorAmount = 0;
    public float FloorAmount => floorAmount;

    private float lastFloorY = 0;
    public float LastFloorY => lastFloorY;

    public UnityEvent OnLevelWasGenerated;

    public void Generate(int level)
    {
        DestroyChild();

        floorAmount = defaultFloorAmount + level;

        axis.transform.localScale = new Vector3(1, floorAmount * floorHeight + floorHeight, 1);

        for(int i = 0; i < floorAmount; i++)
        {
            Floor floor = Instantiate(floorPrefab, transform); // берем transform главного объекта и в нем создаем дочерние объекты floor
            floor.transform.Translate(0, i * floorHeight, 0);
            floor.name = "Floor " + i;

            if (i == 0)
            {
                floor.SetFinishAllSegment();
            }

            else if (i == floorAmount - 1)
            {
                floor.AddEmptySegment(2);
                lastFloorY = floor.transform.position.y;
            }
            
            else if (i > 0 && i < floorAmount - 1)
            {
                floor.AddEmptySegment(emptySegmentAmount);
                floor.AddRandomTrapSegment(Random.Range(randomMinRange, randomMaxRange + 1));
                floor.SetRandomRotationSegment();
            }
            
        }
        Debug.Log("INVOKE LEVELWASGENERATED!");
        OnLevelWasGenerated.Invoke();
    }

    private void DestroyChild()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i)!= axis)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}

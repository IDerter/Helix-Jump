using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreText : BallEvents
{
    [SerializeField] private Text scoreLevelText;
    [SerializeField] private Text scoreMaxText;

    [SerializeField] private ScoreCollector scoreLevel;
    [SerializeField] private ScoreCollector scoreMax;

    private void Start()
    {
        scoreMaxText.text = scoreMax.MaxScore.ToString();
    }

    protected override void OnBallColissionSegment(SegmentType type)
    {
       if (type != SegmentType.Trap)
        {
            scoreLevelText.text = scoreLevel.Scores.ToString();
        }
       if (type == SegmentType.Finish)
        {
            scoreMaxText.text = scoreMax.MaxScore.ToString();
        }
    }
}

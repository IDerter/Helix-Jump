using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelProgress : BallEvents
{

    private int currentLevel = 1;

    //геттер currentLevel
    public int CurrentLevel => currentLevel;


    protected override void Awake()
    {
        base.Awake();

        Load("LevelProgress:currentLevel", 1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Reset();
        }
    }

    protected override void OnBallColissionSegment(SegmentType type)
    {
        if (type == SegmentType.Finish)
        {
            currentLevel++;
            Save("LevelProgress:currentLevel", currentLevel);
        }
    }

    private void Save(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    private void Load(string key, int value)
    {
        currentLevel = PlayerPrefs.GetInt(key, value);
    }

    private void Reset()
    {
        PlayerPrefs.DeleteAll();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

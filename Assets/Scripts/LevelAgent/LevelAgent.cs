using UnityEngine;

public class LevelAgent : MonoBehaviour
{
    private int     _currentLevel;
    private Level   _level;

    public LevelAgent()
    {
        _currentLevel = 0;
    }
    public void Nextlevel()
    {
        LoadLevel(_currentLevel++);
    }

    private void LoadLevel(int levelNumber)
    {
        switch(levelNumber)
        {
            case 0: _level = new Level0(); break;
            //case 1: _level = new Level1(); break;
        }
        _level.buildLevel();
    }
    void Start()
    {
        Nextlevel();
    }
}

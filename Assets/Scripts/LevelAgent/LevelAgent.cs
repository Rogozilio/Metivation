using UnityEngine;

public class LevelAgent : MonoBehaviour
{
    private int     _currentLevel = 0;
    private bool    _isDefaultRespawn = true;
    private Level   _level;

    public void Nextlevel()
    {
        LoadLevel(_currentLevel++);
    }

    private void LoadLevel(int levelNumber)
    {
        switch(levelNumber)
        {
            case 0: _level = new Level0(); break;
            case 1: _level = new Level1(); break;
        }
        _level.BuildLevel(_isDefaultRespawn);
        _isDefaultRespawn = !_isDefaultRespawn;
    }
    private void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Finish").Length == 0)
        {
            Nextlevel();
        }
    }
}
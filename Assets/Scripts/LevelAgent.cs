using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private int _currentLevel;
    private void Nextlevel()
    {
        _currentLevel++;
        LoadLevel();
    }

    private void LoadLevel()
    {

    }
}

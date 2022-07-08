using UIScripts;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private UnitTypeEnum type;
    private GameManager _gameManager;
    private UIManager _uiManager;
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _uiManager = FindObjectOfType<UIManager>();
    }

    private void OnMouseEnter()
    {
        if (!_gameManager.SelectPhase) return;
        
        GetComponent<Renderer>().material.color = Color.green;
    }

    private void OnMouseExit()
    {
        if (!_gameManager.SelectPhase) return;
        
        GetComponent<Renderer>().material.color = Color.cyan;
    }

    private void OnMouseDown()
    {
        if (!_gameManager.SelectPhase) return;

        if (_gameManager.AllyData.gold <= 5)
        {
            _uiManager.MakeUnselectable();
            _gameManager.AllyData.gold -= 5;
            _gameManager.SpawnEnemy(gameObject.transform.position + Vector3.up, type);
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
}

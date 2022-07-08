using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private bool isAlly;
    
    private float _passedTime;

    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

 
}
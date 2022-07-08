using System;
using DG.Tweening;
using UnityEngine;

public enum UnitState
{
    Moving,
    Attacking
};

public class Unit : MonoBehaviour
{
    public int _health;
    public int _damage;
    public int _speed;
    public float _range;
    public bool _isAlly;
    public int expAmount;
    public int goldAmount;
    
    public UnitTypeEnum _unitType;
    public UnitState _unitState;
    public SoTemplates _valueTemplate;
    
    public Unit _target;
    public GameObject _destination;

    public GameManager _gameManager;
    // Start is called before the first frame update

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (_unitState)
        {
            case UnitState.Moving:
                //Needs rework
                transform.DOMoveX(_destination.transform.position.x, _speed);
                break;
            
            case UnitState.Attacking:
                Attack(_target);
                break;
            
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void Attack(Unit targetObject)
    {
        targetObject._health -= _damage;
        if (targetObject._health <= 0)
        {
            targetObject.gameObject.SetActive(false);
        }
    }
    

    public void UpdateStats(SoTemplates template)
    {
        switch (_unitType)
        {
            case UnitTypeEnum.LightUnit:
                _health = template.lightUnitValues.health;
                _damage = template.lightUnitValues.damage;
                _speed = template.lightUnitValues.speed;
                _range = template.lightUnitValues.range;
                break;
            
            case UnitTypeEnum.MediumUnit:
                _health = template.mediumUnitValues.health;
                _damage = template.mediumUnitValues.damage;
                _speed = template.mediumUnitValues.speed;
                _range = template.mediumUnitValues.range;
                break;
            
            case UnitTypeEnum.HeavyUnit:
                _health = template.heavyUnitValues.health;
                _damage = template.heavyUnitValues.damage;
                _speed = template.heavyUnitValues.speed;
                _range = template.heavyUnitValues.range;
                break;
            
            case UnitTypeEnum.SpecialUnit:
                _health = template.specialUnitValues.health;
                _damage = template.specialUnitValues.damage;
                _speed = template.specialUnitValues.speed;
                _range = template.specialUnitValues.range;
                break;
            
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private void OnEnable()
    {
        _gameManager.activeUnits.Add(gameObject);
    }

    private void OnDisable()
    {
        _gameManager.activeUnits.Remove(gameObject);
    }
}

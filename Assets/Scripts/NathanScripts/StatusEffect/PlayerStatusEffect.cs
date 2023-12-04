using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusEffect : MonoBehaviour, IEffectable
{
    private float _maxHealth = 100f;
    [SerializeField] public float _currentHealth;
    private StatusEffectData _data;
    public playerHealth playerhealth;
    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (_data != null) {
            HandleEffect();
        }
    }

    private float _currentEffectTime = 0f;
    private float _nextTickTime = 0f;

    public void ApplyEffect(StatusEffectData _data)
    {
        this._data = _data;
    }
    public void RemoveEffect()
    {
        _data = null;
        _currentEffectTime = 0;
        _nextTickTime = 0;
    }

    public void HandleEffect()
    {
        _currentEffectTime += Time.deltaTime;
        if (_currentEffectTime >= _data.Lifetime){
            RemoveEffect();
        }
        if (_data == null) { return; }
        if (_data.DOTAmount != 0 && _currentEffectTime > _nextTickTime){
            _nextTickTime += _data.TickSpeed;
            _currentHealth -= _data.DOTAmount;
            playerhealth.health -= _data.DOTAmount;
            playerhealth.lerpTimer = 0;
            //Debug.Log(_currentHealth);
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
        }
    }
}

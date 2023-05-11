using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    [SerializeField] private IntEventSO _rewardEvent;
    [SerializeField] private IntEventSO _rewardUpdateEvent;

    public int _currentReward = 0;
    public int GetCurrentHP() => _currentReward;

    private void Start()
    {
        _rewardEvent.Event += UpdateReward;
    }
    private void OnDestroy()
    {
        _rewardEvent.Event -= UpdateReward;
    }

    private void UpdateReward(int healedHP)
    {
        _currentReward += healedHP;
       // _currentReward = Mathf.Clamp(_currentReward, 0, 100);

        _rewardUpdateEvent.Invoke(_currentReward);
    }
}

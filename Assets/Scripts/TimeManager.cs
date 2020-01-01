using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField ]public float targetTime = 10;
    public int abilityNumber;

    void Update()
    {
        if (targetTime > 0)
        {
       targetTime -= Time.unscaledDeltaTime;
        }
        if (targetTime <= 0)
        {
            FindObjectOfType<AbilityManager>().EndAbility(abilityNumber);
            Destroy(gameObject);
        }
    }
}

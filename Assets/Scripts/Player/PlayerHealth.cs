using UnityEngine;
using UnityEngine.UI;
public enum HealthState
{
    //데미지 받고있는중
    TakingDamage,
    // 데미지 안받고있는중
    NotTakingDamage
}
public class PlayerHealth : MonoBehaviour
{
   public Image playerHealthSlider;
    public HealthState healthState;
   public int maxHealth = 100; 
    public void TakeDamage(float damage)
    {
        playerHealthSlider.fillAmount -= damage;
    }
}

using UnityEngine;

public class CardFactory
{
    public ICard CreateCard(int id)
    {
        switch (id)
        {
            case 0:
                return new AppleCard();
            case 1:
                return new ShieldCard();
            case 2:
                return new GunCard();
            case 3:
                return new ScoreCard();
            case 4:
                return new GoggleCard();
            case 5:
                return new DrillCard();
            case 6:
                return new ShoesCard();
            case 7:
                return new CloverCard();
            case 8:
                return new IceCard();
            case 9:
                return new PerfectGoggleCard();                                                         
            case 10:
                return new BootsCard();
            case 11:
                return new IceBootsCard();
            case 12:
                return new FurBootsCard();
            case 13:
                return new HeavyBootsCard();
            default:
                Debug.LogError("Invalid card ID");
                return null;
        }
    }
}
public class AppleCard : ICard
{
    public void UseCard()
    {
        Debug.Log("최대 체력이 증가합니다!");
    }
}

public class ShieldCard : ICard
{
    public void UseCard()
    {
        CardManager.Instance.ShieldActive = true;
        Debug.Log("실드가 부여됩니다!");                                                                                                                                                                                                                                                
    }
}

public class GunCard : ICard
{
    public void UseCard()                                               
    {
        CardManager.Instance.BulletActive = true;
        Debug.Log("권총이 발사됩니다!");
    }
}

public class ScoreCard : ICard
{
    public void UseCard()
    {
        CardManager.Instance.ScoreBoostActive = true;
        Debug.Log("획득 범위가 증가합니다!");
    }
}

public class GoggleCard : ICard
{
    public void UseCard()
    {
        Debug.Log("점수 증가량이 상승합니다!");
    }
}

public class DrillCard : ICard
{
    public void UseCard()
    {
        CardManager.Instance.DrillActive = true;
        Debug.Log("앞 장애물이 제거됩니다!");
    }
}

public class ShoesCard : ICard
{
    public void UseCard()
    {
        Debug.Log("가시류 함정 데미지가 감소합니다!");
    }
}

public class CloverCard : ICard
{

    public void UseCard()
    {
        Debug.Log("골드 획득량이 증가합니다!");
    }
}

//초원 카드


public class IceCard : ICard
{
    public void UseCard()
    {
        Debug.Log("체력 회복 물이 생성됩니다!");
    }
}

public class PerfectGoggleCard : ICard
{

    public void UseCard()
    {
        Debug.Log("사막에서 시야가 확보됩니다!");
    }
}

public class BootsCard : ICard
{

    public void UseCard()
    {
        Debug.Log("가시류 함정 피해가 대폭 감소합니다!");
    }
}

public class IceBootsCard : ICard
{

    public void UseCard()
    {
        Debug.Log("용암 지속딜이 삭제됩니다!");
    }
}

public class FurBootsCard : ICard                                               
{       
    public void UseCard()
    {
        Debug.Log("얼음 지속딜이 삭제됩니다!");
    }
}

public class HeavyBootsCard : ICard
{
                                            
    public void UseCard()
    {
        Debug.Log("가시류 함정 피해가 거의 무효화됩니다!");
    }
}

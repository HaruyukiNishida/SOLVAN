using UnityEngine;

public class GameClear : MonoBehaviour
{
    [SerializeField] GameObject _effectL;
    [SerializeField] GameObject _effectR;

    public void ClearSub(bool isParfect)
    {
        if (isParfect)
        {
            AudioManager.instance.PlaySE(TypePlaySE.drram);

            Instantiate(_effectL, CamPoint.Instance.GetCorner
                (CamPoint.TypeCorners.BottomLeft), Quaternion.identity);

            Instantiate(_effectR, CamPoint.Instance.GetCorner
                (CamPoint.TypeCorners.BottomRight), Quaternion.identity);
        }
        else
        {
            AudioManager.instance.PlaySE(TypePlaySE.Vibraslap);
        }
    }
}

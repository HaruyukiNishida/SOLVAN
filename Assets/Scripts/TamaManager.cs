using TMPro;
using UnityEngine;

public class TamaManager : MonoBehaviour
{
    [SerializeField] public int keta = 1;

    private Tama1[] tamas = new Tama1[5];

    private void Awake()
    {
        tamas = GetComponentsInChildren<Tama1>();
    }

    public Tama1[] GetTamas()
    {
        return this.GetComponentsInChildren<Tama1>();
    }

    public int GetSubTotal()
    {
        var subTotal = 0;
        for (int i = 0; i <= 4; i++)
        {
            subTotal += (tamas[i].moveStatus == TamaStatus.On) ? ((i == 4) ? 5 : 1) : 0;
        }

        return subTotal * keta;
    }

    public void SetPositionTama(int value)
    {
        if (value > 4)
        {
            tamas[4].SetPositionTama(true);
            value -= 5;
        }
        else
        {
            tamas[4].SetPositionTama(false);
        }

        for (int i = 0; i < 4; i++)
        {
            tamas[i].SetPositionTama(i < value);
        }
    }

    public void SetTamasInit()
    {
        for (int i = 0; i <= 4; i++)
        {
            tamas[i].TamaPosInit();
        }
    }

}

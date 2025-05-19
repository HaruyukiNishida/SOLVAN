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

}

using TMPro;
using UnityEngine;

public class TamaManager : MonoBehaviour
{

    [SerializeField] Tama1[] tamas = new Tama1[5];

    public TextMeshProUGUI txt;

    public int subTotal = 0;
    public int keta = 1;

    private void Awake()
    {
        

    }

    void Start()
    {
    }

    void Update()
    {
    }

    public void SetTamas(Tama1[] tamas)
    {
        this.tamas = tamas;
    }

    public void DispSubTotal()
    {

        txt.text = DispSubTotalSub().ToString();
    }

    public int DispSubTotalSub()
    {
        subTotal = 0;
        for (int i = 0; i <= 4; i++)
        {
            subTotal += (tamas[i].isOn) ? ((i == 4) ? 5 : 1) : 0;
        }

        return subTotal * keta;

    }


    public void MoveTamas(int index, TamaStatus movestatus)
    {
        if (movestatus == TamaStatus.Up)
        {
            for (int i = index; i < 4; i++)
            {
                if (tamas[i].moveStatus == TamaStatus.Stop)
                {
                    tamas[i].SetTamaMove(movestatus);
                }
            }
        }
        else
        {
            for (int i = index; i >= 0; i--)
            {
                if (tamas[i].moveStatus == TamaStatus.Stop)
                {
                    tamas[i].SetTamaMove(movestatus);
                }
            }

        }
    }
}

using TMPro;
using UnityEngine;

public class VanManager : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI txt;

    TamaManager[] ketas;


    private void Awake()
    {
        ketas = GetComponentsInChildren<TamaManager>();
        //   Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);

    }

   

    public void UpdateTotal()
    {
        txt.text = GetTotal().ToString();
    }

    public int GetTotal()
    {
        var subTotal = 0;
        foreach (TamaManager keta in ketas)
        {
            subTotal += keta.GetSubTotal();
        }

        return subTotal;
    }

}

using UnityEngine;

public class TamaGenerator : MonoBehaviour
{
   [SerializeField] Tama1 tamaPrefab;

    private float tamaHeight=1.0f;
    private float offset = 0.75f;


    void Start()
    {
        TamaGenerate();
    }

    void Update()
    {

    }

    private void TamaGenerate()
    {
        for (int i = 0; i <= 3; i++)
        {
            var posY = i * tamaHeight+offset;
            var tama = Instantiate(tamaPrefab,transform);

            tama.index = i;
            tama.isOn = false;
            tama.transform.localScale=new Vector3(1,1,1);
            tama.transform.Translate(0, posY, 0);

            TamaManager.instance.SetTamas(tama,i);
        }
    }






}

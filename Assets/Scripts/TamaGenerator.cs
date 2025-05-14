using UnityEngine;

public class TamaGenerator : MonoBehaviour
{
    [SerializeField] Tama1 tamaPrefab1;
    [SerializeField] Tama1 tamaPrefab2;

    private float tamaHeight = 1.0f;
    private float offset = 0.75f;

    private float tama2DefaultPosY = 7.25f;



    void Start()
    {
        TamaGenerate();
    }

    void Update()
    {

    }

    private void TamaGenerate()
    {
        Tama1 tama;
        float posY;

        for (int i = 0; i <= 3; i++)
        {
            posY = i * tamaHeight + offset;
            tama = Instantiate(tamaPrefab1, transform);

            tama.index = i;
            tama.isOn = false;
            tama.transform.Translate(0, posY, 0);

            TamaManager.instance.SetTamas(tama, i);
        }

        tama = Instantiate(tamaPrefab2, transform);

        tama.index = 4;
        tama.isOn = false;
        tama.transform.Translate(0, tama2DefaultPosY, 0);
        TamaManager.instance.SetTamas(tama, 4);
    }






}

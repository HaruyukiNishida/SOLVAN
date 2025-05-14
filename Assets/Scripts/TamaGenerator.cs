using UnityEngine;

public class TamaGenerator : MonoBehaviour
{
 //   [SerializeField] Tama1[] tamasPrefab = new Tama1[5];
   

    private float tamaHeight = 1.0f;
    private float offset = 0.75f;

    private float tama2DefaultPosY = 7.25f;



    void Start()
    {
        //TamaGenerate();

     //   TamaManager.instance.SetTamas(tamasPrefab);

    }

    void Update()
    {

    }
/*
    private void TamaGenerate()
    {
        Tama1 tama;
        float posY;

        for (int i = 0; i <= 3; i++)
        {
            posY = i * tamaHeight + offset;
            tama = Instantiate(tamasPrefab[i], transform);

            tama.index = i;
            tama.isOn = false;
            tama.transform.Translate(0, posY, 0);

         //   TamaManager.instance.SetTamas(tama, i);
        }

        tama = Instantiate(tamasPrefab[4], transform);

        tama.index = 4;
        tama.isOn = false;
        tama.transform.Translate(0, tama2DefaultPosY, 0);
      //  TamaManager.instance.SetTamas(tama, 4);
    }





    */
}

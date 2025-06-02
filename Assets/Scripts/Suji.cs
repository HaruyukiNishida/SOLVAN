using UnityEngine;

public class Suji : MonoBehaviour
{
    SpriteRenderer _ones;
    SpriteRenderer _tens;
    SpriteRenderer _handreds;

    Sprite[] digitSprites;

    void Awake()
    {
        Transform ones = transform.Find("ones");
        Transform tens = transform.Find("tens");
        Transform handreds = transform.Find("handreds");

        _ones = ones.GetComponent<SpriteRenderer>();
        _tens = ones.GetComponent<SpriteRenderer>();
        _handreds = ones.GetComponent<SpriteRenderer>();

    }


    void Start()
    {

    }

    void Update()
    {

    }

    public void SetSprite(int number)
    {
        if (number >= 100)
        {
            // 3 桁の場合
            _handreds.gameObject.SetActive(true);
            _tens.gameObject.SetActive(true);
            _ones.gameObject.SetActive(true);

            int hundreds = number / 100;
            int tens = (number / 10) % 10;
            int ones = number % 10;

            _handreds.sprite = digitSprites[hundreds];
            _tens.sprite = digitSprites[tens];
            _ones.sprite = digitSprites[ones];
        }
        else if (number >= 10)
        {
            // 2 桁の場合：先頭の Image を非表示（レイアウトが中央に寄せられる）
            _handreds.gameObject.SetActive(false);
            _tens.gameObject.SetActive(true);
            _ones.gameObject.SetActive(true);

            int tens = number / 10;
            int ones = number % 10;
            _tens.sprite = digitSprites[tens];
            _ones.sprite = digitSprites[ones];
        }
        else
        {
            // 1 桁の場合： tens と hundreds を非表示
            _handreds.gameObject.SetActive(false);
            _tens.gameObject.SetActive(false);
            _ones.gameObject.SetActive(true);

            _ones.sprite = digitSprites[number];
        }

    }




}






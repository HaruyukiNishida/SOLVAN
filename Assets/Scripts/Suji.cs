using System;
using Unity.VisualScripting;
using UnityEngine;

public class Suji : MonoBehaviour
{
    SpriteRenderer _ones;
    SpriteRenderer _tens;
    SpriteRenderer _handreds;

    SpriteRenderer[] _sprites;

    void Awake()
    {
        Transform ones = transform.Find("ones");
        Transform tens = transform.Find("tens");
        Transform handreds = transform.Find("handreds");

        _ones = ones.GetComponent<SpriteRenderer>();
        _tens = tens.GetComponent<SpriteRenderer>();
        _handreds = handreds.GetComponent<SpriteRenderer>();

        _sprites = GetComponentsInChildren<SpriteRenderer>();

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

            _handreds.sprite = AtlasManager.instance.GetSprite(hundreds);
            _tens.sprite = AtlasManager.instance.GetSprite(tens);
            _ones.sprite = AtlasManager.instance.GetSprite(ones);
        }
        else if (number >= 10)
        {
            // 2 桁の場合：先頭の Image を非表示（レイアウトが中央に寄せられる）
            _handreds.gameObject.SetActive(false);
            _tens.gameObject.SetActive(true);
            _ones.gameObject.SetActive(true);

            int tens = number / 10;
            int ones = number % 10;
            _tens.sprite = AtlasManager.instance.GetSprite(tens);
            _ones.sprite = AtlasManager.instance.GetSprite(ones);
        }
        else
        {
            // 1 桁の場合： tens と hundreds を非表示
            _handreds.gameObject.SetActive(false);
            _tens.gameObject.SetActive(false);
            _ones.gameObject.SetActive(true);

            _ones.sprite = AtlasManager.instance.GetSprite(number);
        }
    }

    public SpriteRenderer[] GetSprites()
    {
        return _sprites;
    }

    internal void setAlpha()
    {
        foreach (var sprite in _sprites)
        {
         //   if (sprite.gameObject.activeSelf)
            {
                var color = sprite.color;
                color.a = 1f;

                sprite.color = color;
            }
        }
    }
}






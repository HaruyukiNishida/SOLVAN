using System;
using UnityEngine;

public class CamPoint
{
    //instance は public static ではなく private static にする
    //➡ public だと外部から instance を直接変更できてしまうので、Instance を通じてアクセスする形にする のが正しい
    private static CamPoint instance;

    //今作で競合がおこる事はないだろうけど一応
    private static readonly object lockObj = new object(); // スレッドセーフ対策


    private Vector3 _topLeft;
    private Vector3 _topRight;
    private Vector3 _bottomLeft;
    private Vector3 _bottomRight;

    private CamPoint()
    {
        Camera cam = Camera.main;
        float z = cam.transform.position.z;

        z = -z;//今作では意図的にこうしている

        _bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, z));
        _bottomRight = cam.ViewportToWorldPoint(new Vector3(1, 0, z));
        _topLeft = cam.ViewportToWorldPoint(new Vector3(0, 1, z));
        _topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, z));
    }

    public static CamPoint Instance
    {
        get
        {
            lock (lockObj)// スレッドセーフ対策
            {
                if (instance == null) instance = new CamPoint();
                return instance;
            }
        }

    }

    

    public Vector3 GetCorner(TypeCorners corner)
    {
        switch (corner)
        {
            case TypeCorners.BottomLeft:
                return _bottomLeft; // 左下の座標
            case TypeCorners.BottomRight:
                return _bottomRight; // 右下の座標
            case TypeCorners.TopLeft:
                return _topLeft; // 左上の座標
            case TypeCorners.TopRight:
                return _topRight; // 右上の座標
            default:
                throw new ArgumentOutOfRangeException(nameof(corner), "無効");
        }
    }

    public float GetBorder(TypeBorders border)
    {
        switch (border)
        {
            case TypeBorders.Left:
                return _topLeft.x; // 左端のX座標
            case TypeBorders.Right:
                return _topRight.x; // 右端のX座標
            case TypeBorders.Top:
                return _topRight.y; // 上端のY座標
            case TypeBorders.Bottom:
                return _bottomRight.y; // 下端のY座標
            default:
                throw new ArgumentOutOfRangeException(nameof(border), "無効");
        }
    }


    Vector3[] GetPositionsScreenToWorld()
    {
        Camera cam = Camera.main;
        var z = cam.transform.position.z;

        // スクリーン座標の端を取得
        var center = cam.ScreenToWorldPoint(new Vector3(0.5f, 0.5f, z));
        var bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, z));
        var bottomRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, z));
        var topLeft = cam.ScreenToWorldPoint(new Vector3(0, Screen.height, z));
        var topRight = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, z));

        Debug.Log($"BL:{bottomLeft} / BR:{bottomRight} / TL:{topLeft} / TR: {topRight}");

        return new Vector3[]
        {
            center,
            bottomLeft,
            bottomRight,
            topRight,
            topLeft,
        };

    }

    public enum TypeCorners
    {
        BottomLeft,
        BottomRight,
        TopRight,
        TopLeft,

    }

    public enum TypeBorders
    {
        Left,
        Right,
        Top,
        Bottom,

    }
}

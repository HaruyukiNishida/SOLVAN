using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AbacusController : MonoBehaviour
{
    public Camera mainCamera;
    public float moveSpeed = 5f;
    public float minSwipeThreshold = 10f; // Y方向のスワイプ感度
    private Dictionary<int, GameObject> activeBeads = new Dictionary<int, GameObject>();

    void Update()
    {
        if (Input.touchCount >= 1) // 指1本でも動作するように変更
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Moved && Mathf.Abs(touch.deltaPosition.y) > minSwipeThreshold)
                {
                    Ray ray = mainCamera.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.CompareTag("Bead"))
                        {
                            GameObject bead = hit.collider.gameObject;
                            activeBeads[touch.fingerId] = bead;

                            float swipeDirection = Mathf.Sign(touch.deltaPosition.y);
                            MoveBead(bead, swipeDirection);
                        }
                    }
                }
            }
        }

        // 2本の指を使って「上の珠と下の珠を同時にはじく」場合
        if (Input.touchCount >= 2)
        {
            List<GameObject> selectedBeads = new List<GameObject>();

            foreach (Touch touch in Input.touches)
            {
                Ray ray = mainCamera.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Bead"))
                {
                    selectedBeads.Add(hit.collider.gameObject);
                }
            }

            if (selectedBeads.Count >= 2)
            {
                MoveBeadsTogether(selectedBeads);
            }
        }
    }

    private void MoveBead(GameObject bead, float direction)
    {
        Vector3 newPosition = bead.transform.position + new Vector3(0, direction * Time.deltaTime * moveSpeed, 0);
        bead.transform.position = Vector3.Lerp(bead.transform.position, newPosition, 0.5f);
    }

    private void MoveBeadsTogether(List<GameObject> beads)
    {
        foreach (GameObject bead in beads)
        {
            Vector3 newPosition = bead.transform.position + new Vector3(0, 1f * moveSpeed * Time.deltaTime, 0);
            bead.transform.position = Vector3.Lerp(bead.transform.position, newPosition, 0.5f);
        }
    }
}

public class BeadMultiDragHandler : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public float moveSpeed = 5f;
    private Vector3 startPosition;
    private static Dictionary<int, GameObject> activeBeads = new Dictionary<int, GameObject>();

    public void OnBeginDrag(PointerEventData eventData)
    {
        // タッチIDを取得して、珠を管理
        if (!activeBeads.ContainsKey(eventData.pointerId))
        {
            activeBeads[eventData.pointerId] = gameObject;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Y方向にのみ移動を許可
        if (activeBeads.ContainsKey(eventData.pointerId))
        {
            GameObject bead = activeBeads[eventData.pointerId];
            float deltaY = eventData.delta.y * Time.deltaTime * moveSpeed;
            Vector3 newPosition = bead.transform.position + new Vector3(0, deltaY, 0);
            bead.transform.position = Vector3.Lerp(bead.transform.position, newPosition, 0.5f);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // タッチ終了後、リストから削除
        if (activeBeads.ContainsKey(eventData.pointerId))
        {
            activeBeads.Remove(eventData.pointerId);
        }
    }



    void DrawLine(Vector3[] positions)
    {
        LineRenderer renderer = gameObject.GetComponent<LineRenderer>();


        renderer.positionCount = positions.Length;
        // 線を引く場所を指定する
        renderer.SetPositions(positions);

    }

}
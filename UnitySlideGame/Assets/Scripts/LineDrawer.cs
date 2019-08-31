using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LineDrawer : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {

	private GameObject LineObject = null;
	private GameObject LineObjectRoot = null;
	
	private List<GameObject> LineImageObjectList = new List<GameObject>();
	private readonly int LineObjectCount = 1000;

	private List<Vector2> LinePositionList = new List<Vector2>();

    private List<Vector2> MovePositionList = new List<Vector2>();

    public void Initialize(GameObject lineObjectRaw, GameObject root) {
		LineObject = lineObjectRaw;
		LineObjectRoot = root;

		ClearLineObject();

		for (int i = 0; i < LineObjectCount; i++) {
			GameObject obj = Instantiate(lineObjectRaw) as GameObject;
			obj.transform.SetParent(LineObjectRoot.transform);
			obj.transform.localPosition = Vector3.zero;
			obj.transform.localScale = Vector3.one; obj.SetActive(false); LineImageObjectList.Add(obj);
		}

        MovePositionList.Clear();

    }
	
	public void ResetLineObjectList() {
		for (int i = 0; i < LineImageObjectList.Count; i++) {
			LineImageObjectList[i].SetActive(false);
		}
	}

	public void ClearLineObject() {
		for (int i = 0; i < LineImageObjectList.Count; i++) {
			LineImageObjectList[i].transform.SetParent(null);
			Destroy(LineImageObjectList[i]);
			LineImageObjectList[i] = null;
		}
		LineImageObjectList.Clear();
	}

	public void OnBeginDrag(PointerEventData eventData) {
		ResetLineObjectList();
		LinePositionList.Clear();
        MovePositionList.Clear();

        float width = Screen.width;
        float height = Screen.height;
        float widthOffset = width / 2;
        float heightOffset = height / 2;
        Vector3 offsetMousePosition = new Vector3(Input.mousePosition.x - widthOffset, Input.mousePosition.y - heightOffset, 0);
        LinePositionList.Add(offsetMousePosition);

        MovePositionList.Add(offsetMousePosition);

        DrawLine();
	}

	public void OnDrag(PointerEventData eventData) {
		if (FindFreeLineObject() == null) {
			return;
		}
        float width = Screen.width;
        float height = Screen.height;
        float widthOffset = width / 2;
        float heightOffset = height / 2;
        Vector2 last = LinePositionList[LinePositionList.Count - 1];
        Vector3 prevLast = new Vector3(last.x, last.y);

        Vector3 offsetMousePosition = new Vector3(Input.mousePosition.x - widthOffset, Input.mousePosition.y - heightOffset, 0);
		InterporationLine(prevLast, offsetMousePosition, true);
		DrawLine();
		LinePositionList.Clear();
		LinePositionList.Add(offsetMousePosition);

        MovePositionList.Add(offsetMousePosition);
    }

    private void DrawLine() {
		Debug.Log(LinePositionList.Count);
		for (int i = 0; i < LinePositionList.Count; i++) {
			GameObject obj = FindFreeLineObject();
			if (obj == null) {
				return;
			}
			obj.SetActive(true);
			obj.transform.localPosition = new Vector3(LinePositionList[i].x, LinePositionList[i].y, 0);
		}
	}

	private GameObject FindFreeLineObject() {
		GameObject obj = null;

		for (int i = 0; i < LineImageObjectList.Count; i++) {
			if (LineImageObjectList[i].activeSelf == false) {
				obj = LineImageObjectList[i];
				break;
			}
		}

		return obj;
	}

	private void InterporationLine(Vector3 start, Vector3 end, bool isFromStart) {
		Rect startRect = new Rect(start.x, start.y, 4f, 4f);
		Rect endRect = new Rect(end.x, end.y, 4f, 4f);
		if (startRect.Overlaps(endRect) == false) {
			Vector3 center = new Vector3((end.x+start.x)/2, (end.y + start.y)/2, 0f);
			InterporationLine(start, center, true);
			InterporationLine(center, end, false);
		} else {
			if (isFromStart) {
				LinePositionList.Add(new Vector2(start.x, start.y));
			}
			LinePositionList.Add(new Vector2(end.x, end.y));
		}
	}

	public void OnEndDrag(PointerEventData eventData) {
		//if (transform.parent == canvasTransform)
		//{
		//	transform.SetParent(parentTransform);
		//}
		//dragObject = null;
		//CanvasGroup.blocksRaycasts = true;
		//CanvasGroup.alpha = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public List<Vector2> GetMovePositionList() {
		return MovePositionList;
	}
}

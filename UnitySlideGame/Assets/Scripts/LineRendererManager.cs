using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineRendererManager : BestPracticeSingleton<LineRendererManager> {

	[SerializeField]
	private LineDrawer LineDrawer;
	
	[SerializeField]
	private GameObject LineObject;

	[SerializeField]
	private GameObject LineObjectRoot;

    [SerializeField]
    private CanvasScaler CuCanvasScaler;

    public void Initialize() {
		LineDrawer.Initialize(LineObject, LineObjectRoot, CuCanvasScaler.referenceResolution);
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public List<Vector2> GetMovePositionList() {
		return LineDrawer.GetMovePositionList();
	}
}

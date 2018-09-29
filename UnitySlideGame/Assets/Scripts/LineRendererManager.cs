using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererManager : BestPracticeSingleton<LineRendererManager> {

	[SerializeField]
	private LineDrawer LineDrawer;
	
	[SerializeField]
	private GameObject LineObject;

	[SerializeField]
	private GameObject LineObjectRoot;

	public void Initialize() {
		LineDrawer.Initialize(LineObject, LineObjectRoot);
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public List<Vector2> GetMovePositionList() {
		return LineDrawer.GetMovePositionList();
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//四角（三角2面）作製（折り返しなし）
public class Chutrial2 : MonoBehaviour {
	//頂点座標
	Vector3[] Vertex = new Vector3[4];

	//面情報
	int[] Face = new int[6] {   0, 1, 2,
								1, 3, 2 };

	//マテリアル
	public Material material;

	void Start() {
		DisplayObject();
		DisplayCaption("三角ポリゴン*2");
	}

	//三角ポリゴン*2表示
	private void DisplayObject() {
		//必要なものをアタッチ
		MeshFilter meshFilter
			= this.gameObject.AddComponent<MeshFilter>();
		MeshRenderer meshRenderer
			= this.gameObject.AddComponent<MeshRenderer>();

		//頂点計算
		CalcVertices();

		//合成用インスタンスの配列
		CombineInstance[] combineInstanceAry = new CombineInstance[1];
		//合成用メッシュインスタンスのメッシュ領域を確保する
		combineInstanceAry[0].mesh = new Mesh();
		//頂点情報を追加
		combineInstanceAry[0].mesh.vertices = Vertex;
		//面情報を追加
		combineInstanceAry[0].mesh.triangles = Face;
		//おまじない
		combineInstanceAry[0].transform = Matrix4x4.Translate(Vector3.zero);

		//メッシュの入れ先を確保する
		meshFilter.mesh = new Mesh();
		//メッシュのアタッチと合成
		meshFilter.mesh.CombineMeshes(combineInstanceAry);

		//NormalMapの再計算
		meshFilter.mesh.RecalculateNormals();
		//マテリアルアタッチ
		meshRenderer.material = material;
	}

	//頂点計算
	private void CalcVertices() {
		//基点座標
		Vertex[0] = new Vector3(0, 0, 0);
		Vertex[1] = new Vector3(0, 1, 0);
		Vertex[2] = new Vector3(1, 0, 0);
		Vertex[3] = new Vector3(1, 1, 0);
	}

	//キャプション表示
	private void DisplayCaption(string caption) {
		GameObject captionObj = new GameObject();
		captionObj.transform.localScale = new Vector3(0.035f, 0.035f, 0.035f);
		TextMesh textMesh = captionObj.AddComponent<TextMesh>();

		textMesh.fontSize = 200;
		textMesh.text = caption;
	}
}

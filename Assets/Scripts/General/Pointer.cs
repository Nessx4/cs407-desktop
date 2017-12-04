﻿/*	A Pointer can belong to the desktop player or a mobile player. The desktop player
 *	has their own white Pointer, while each mobile Pointer has the same sprite with
 *	a different colour and a mobile icon below it.
 */

using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(SpriteRenderer))]
public class Pointer : MonoBehaviour
{
	[SerializeField]
	private Sprite desktopPointer;

	[SerializeField]
	private Sprite mobilePointer;

	private PointerType type;

	public Camera cam;
    private float speed = 15.0f;

	private new SpriteRenderer renderer;

	private void Start()
	{
		renderer = GetComponent<SpriteRenderer>();
		cam = Camera.main;
	}

	public void SetPointerType(PointerType type, int id)
	{
		this.type = type;

		if(renderer == null)
			renderer = GetComponent<SpriteRenderer>();

		if (type == PointerType.DESKTOP)
		{
			renderer.sprite = desktopPointer;
			Cursor.visible = false;
		}
		else
		{
			renderer.sprite = mobilePointer;

			switch (id)
			{
				case 0:
					renderer.color = Color.red;
					break;
				case 1:
					renderer.color = Color.blue;
					break;
				case 2:
					renderer.color = Color.yellow;
					break;
				case 3:
					renderer.color = Color.green;
					break;
			}
		}
	}

	public void Move(Vector2 move)
	{
		transform.position += new Vector3(-move.x, move.y, 0.0f) * speed;
	}

	public void SetPosition(Vector2 pos)
	{
		transform.position = new Vector3(pos.x, pos.y, 0.0f);
	}

	private void LateUpdate()
	{
		Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0, Screen.width);
        pos.y = Mathf.Clamp(pos.y, 0, Screen.height);
        transform.position = Camera.main.ScreenToWorldPoint(pos);
	}
}

public enum PointerType
{
	DESKTOP, MOBILE
}
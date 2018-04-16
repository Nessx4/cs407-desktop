﻿using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EditorTileData 
{
	private Dictionary<ThemeType, ThemeData> themeDataMap;

	public EditorTileData()
	{
		themeDataMap = new Dictionary<ThemeType, ThemeData>();

		ThemeData dat = new ThemeData();
		dat.Add(TileType.NONE,
			new TileData
			(
				null,
				null,
				"Null"
			)
		);

		dat.Add(TileType.SOLID,				
			new TileData
			(
				Resources.Load<GridTile>("TilePrefabs/Editor/Normal/obj_Solid"),
				Resources.Load<Sprite>("UI/TileIcons/Normal/tx_TileIcon_Solid"),
				"Solid Block"
			)
		);

		dat.Add(TileType.SEMISOLID,				
			new TileData
			(
				Resources.Load<GridTile>("TilePrefabs/Editor/Normal/obj_Semisolid"),
				Resources.Load<Sprite>("UI/TileIcons/Normal/tx_TileIcon_Semisolid"),
				"Semi-Solid Platform"
			)
		);

		dat.Add(TileType.LADDER,				
			new TileData
			(
				Resources.Load<GridTile>("TilePrefabs/Editor/Normal/obj_Ladder"),
				Resources.Load<Sprite>("UI/TileIcons/Normal/tx_TileIcon_Ladder"),
				"Ladder"
			)
		);

		dat.Add(TileType.MOVING_PLATFORM,				
			new TileData
			(
				Resources.Load<GridTile>("TilePrefabs/Editor/Normal/obj_MovingPlatform"),
				Resources.Load<Sprite>("UI/TileIcons/Normal/tx_TileIcon_MovingPlatform"),
				"Moving Platform"
			)
		);

		dat.Add(TileType.TREADMILL,				
			new TileData
			(
				Resources.Load<GridTile>("TilePrefabs/Editor/Normal/obj_Treadmill"),
				Resources.Load<Sprite>("UI/TileIcons/Normal/tx_TileIcon_Treadmill"),
				"Treadmill"
			)
		);

		dat.Add(TileType.START_POINT,				
			new TileData
			(
				Resources.Load<GridTile>("TilePrefabs/Editor/Normal/obj_StartPoint"),
				Resources.Load<Sprite>("UI/TileIcons/Normal/tx_TileIcon_StartPoint"),
				"Start Point"
			)
		);

		dat.Add(TileType.CHECK_POINT,				
			new TileData
			(
				Resources.Load<GridTile>("TilePrefabs/Editor/Normal/obj_CheckPoint"),
				Resources.Load<Sprite>("UI/TileIcons/Normal/tx_TileIcon_CheckPoint"),
				"Check Point"
			)
		);

		dat.Add(TileType.END_POINT,				
			new TileData
			(
				Resources.Load<GridTile>("TilePrefabs/Editor/Normal/obj_EndPoint"),
				Resources.Load<Sprite>("UI/TileIcons/Normal/tx_TileIcon_EndPoint"),
				"End Point"
			)
		);

		dat.Add(TileType.BUSH,				
			new TileData
			(
				Resources.Load<GridTile>("TilePrefabs/Editor/Normal/obj_Bush"),
				Resources.Load<Sprite>("UI/TileIcons/Normal/tx_TileIcon_Bush"),
				"Bush"
			)
		);

		dat.Add(TileType.CLOUD,				
			new TileData
			(
				Resources.Load<GridTile>("TilePrefabs/Editor/Normal/obj_Cloud"),
				Resources.Load<Sprite>("UI/TileIcons/Normal/tx_TileIcon_Cloud"),
				"Cloud"
			)
		);

		dat.Add(TileType.MOUNTAIN,				
			new TileData
			(
				Resources.Load<GridTile>("TilePrefabs/Editor/Normal/obj_Mountain"),
				Resources.Load<Sprite>("UI/TileIcons/Normal/tx_TileIcon_Mountain"),
				"Mountain"
			)
		);

		dat.Add(TileType.CRATE,				
			new TileData
			(
				Resources.Load<GridTile>("TilePrefabs/Editor/Normal/obj_Crate"),
				Resources.Load<Sprite>("UI/TileIcons/Normal/tx_TileIcon_Crate"),
				"Crate"
			)
		);

		dat.Add(TileType.SWEETS,				
			new TileData
			(
				Resources.Load<GridTile>("TilePrefabs/Editor/Normal/obj_Sweets"),
				Resources.Load<Sprite>("UI/TileIcons/Normal/tx_TileIcon_Sweets"),
				"Sweets"
			)
		);

		dat.Add(TileType.UFO,				
			new TileData
			(
				Resources.Load<GridTile>("TilePrefabs/Editor/Normal/obj_Ufo"),
				Resources.Load<Sprite>("UI/TileIcons/Normal/tx_TileIcon_Ufo"),
				"UFO"
			)
		);

		dat.Add(TileType.SLIME,				
			new TileData
			(
				Resources.Load<GridTile>("TilePrefabs/Editor/Normal/obj_Slime"),
				Resources.Load<Sprite>("UI/TileIcons/Normal/tx_TileIcon_Slime"),
				"Slime"
			)
		);

		dat.Add(TileType.SPAWNER,				
			new TileData
			(
				Resources.Load<GridTile>("TilePrefabs/Editor/Normal/obj_Spawner"),
				Resources.Load<Sprite>("UI/TileIcons/Normal/tx_TileIcon_Spawner"),
				"Spawner"
			)
		);

		themeDataMap.Add(ThemeType.NORMAL, dat);
	}

	public GridTile GetTilePrefab(TileType tileType, ThemeType themeType)
	{
		return themeDataMap[themeType][tileType].gridPrefab;
	}

	public Sprite GetPaletteIcon(TileType tileType, ThemeType themeType)
	{
		return themeDataMap[themeType][tileType].paletteSprite;
	}

	public string GetTileName(TileType tileType, ThemeType themeType)
	{
		return themeDataMap[themeType][tileType].name;
	}
}

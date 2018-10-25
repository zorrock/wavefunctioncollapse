﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class Orientations {
	private static Quaternion[] rotations;
	private static Vector3[] vectors;
	private static Vector3i[] directions;

	public static Quaternion[] Rotations {
		get {
			if (Orientations.rotations == null) {
				Orientations.initialize();
			}
			return Orientations.rotations;
		}
	}

	public static Vector3i[] Direction {
		get {
			if (Orientations.directions == null) {
				Orientations.initialize();
			}
			return Orientations.directions;
		}
	}



	public const int LEFT = 0;
	public const int DOWN = 1;
	public const int BACK = 2;
	public const int RIGHT = 3;
	public const int UP = 4;
	public const int FORWARD = 5;

	private static void initialize() {
		Orientations.vectors = new Vector3[] {
			Vector3.left,
			Vector3.down,
			Vector3.back,
			Vector3.right,
			Vector3.up,
			Vector3.forward
		};

		Orientations.rotations = Orientations.vectors.Select(vector => Quaternion.LookRotation(vector)).ToArray();
		Orientations.directions = Orientations.vectors.Select(vector => new Vector3i(vector)).ToArray();
	}

	private static readonly int[] horizontalFaces = { 0, 2, 3, 5 };

	public static readonly string[] Names = { "-red", "-green", "-blue", "red", "green", "blue" };

	public static int Rotate(int direction, int rotations) {
		if (direction == 1 || direction == 4) {
			return direction;
		}
		return horizontalFaces[(Array.IndexOf(horizontalFaces, direction) + rotations) % 4];
	}

	public static bool IsHorizontal(int orientation) {
		return orientation != 1 && orientation != 4;
	}

	public static int GetIndex(Vector3 direction) {
		if (direction.x < 0) {
			return 0;
		} else if (direction.y < 0) {
			return 1;
		} else if (direction.z < 0) {
			return 2;
		} else if (direction.x > 0) {
			return 3;
		} else if (direction.y > 0) {
			return 4;
		} else {
			return 5;
		}
	}
}
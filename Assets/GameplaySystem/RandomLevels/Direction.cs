using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction {
    public int direction = 0;

    private static Direction forward = null;

    public static Direction Forward {
        get {
            if (forward == null) {
                forward = new Direction (0);
            }
            return forward;
        }
    }

    private static Direction right = null;

    public static Direction Right {
        get {
            if (right == null) {
                right = new Direction (1);
            }
            return right;
        }
    }

    private static Direction backward = null;

    public static Direction Backward {
        get {
            if (backward == null) {
                backward = new Direction (2);
            }
            return backward;
        }
    }

    private static Direction left = null;

    public static Direction Left {
        get {
            if (left == null) {
                left = new Direction (3);
            }
            return left;
        }
    }

    public Direction (int direction) {
        this.direction = direction;
    }

    public Direction () {
        this.direction = Random.Range (0, 4);
    }

    public Direction RotateRight () {
        direction += 1;
        direction = direction % 4;

        return this;
    }

    public Direction RotateLeft () {
        direction -= 1;
        if (direction == -1) {
            direction = 3;
        }

        return this;
    }

    public Direction RotateRightAndReturnNewDirection () {
        Direction newDirection = new Direction (this.direction);
        newDirection.direction += 1;
        newDirection.direction = newDirection.direction % 4;

        return newDirection;
    }

    public Direction RotateLeftAndReturnNewDirection () {
        Direction newDirection = new Direction (this.direction);
        newDirection.direction -= 1;
        if (newDirection.direction == -1) {
            newDirection.direction = 3;
        }

        return newDirection;
    }

    public Direction RandomlyRotateLeftOrRight () {
        if (Random.Range (0, 2) == 0) {
            RotateLeft ();
        } else {
            RotateRight ();
        }

        return this;
    }

    public Direction RandomlyRotateLeftOrRightAndCreateNewDirection () {
        Direction newDirection = new Direction (this.direction);
        if (Random.Range (0, 2) == 0) {
            return newDirection.RotateLeft ();
        } else {
            return newDirection.RotateRight ();
        }
    }

    public Quaternion ToQuaternion () {
        switch (direction) {
            case 0:
                return Quaternion.Euler (0, 0, 0);
            case 1:
                return Quaternion.Euler (0, -90, 0);
            case 2:
                return Quaternion.Euler (0, 180, 0);
            default:
                return Quaternion.Euler (0, 90, 0);
        }
    }

    public override string ToString () {
        switch (direction) {
            case 0:
                return "Forward";
            case 1:
                return "Right";
            case 2:
                return "Backward";
            default:
                return "Left";
        }
    }
}

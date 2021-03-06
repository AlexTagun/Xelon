﻿using UnityEngine;

public class XMath
{
    //Vector actions
    public static Vector3 getDiractionVectorForAngle(float inAngle) {
        float theAngleRadians = inAngle * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(theAngleRadians), Mathf.Sin(theAngleRadians), 0.0f);
    }

    public static void getFromTransform(
        ref Vector2 outWorldPosition, ref float outWorldRotation,
        Transform inTransform)
    {
        outWorldPosition = inTransform.position;

        Quaternion theLocalRotation = Quaternion.Euler(
            0.0f, 0.0f, inTransform.rotation.eulerAngles.z
        );

        Transform theParentTransform = inTransform.gameObject.transform.parent;
        Quaternion theWorldRotation = theParentTransform ?
            theLocalRotation : theParentTransform.rotation * theLocalRotation;

        outWorldRotation = theWorldRotation.eulerAngles.z;
    }

    public static void getFromTransform(
        ref Vector2 outWorldPosition, ref float outWorldRotatioin,
        GameObject inObjectWithTransform)
    {
        getFromTransform(ref outWorldPosition, ref outWorldRotatioin,
            inObjectWithTransform.transform
        );
    }

    public static Vector3 getVectorRotatedBy90Degrees(Vector3 inVector) {
        return new Vector3(-inVector.y, inVector.x, 0.0f);
    }

    public static Vector2 rotate(Vector2 inVector, float inDegrees) {
        float theDegrees = inDegrees * Mathf.Deg2Rad;
        float theSin = Mathf.Sin(theDegrees);
        float theCos = Mathf.Cos(theDegrees);

        return new Vector2(
            (theCos * inVector.x) - (theSin * inVector.y),
            (theSin * inVector.x) + (theCos * inVector.y)
        );
    }

    //Numberic
    public static bool equalsWithPrecision(float inValueA, float inValueB, float inPrecision) {
        return Mathf.Abs(inValueA - inValueB) <= inPrecision;
    }

    public static bool hasSameSigns(float inValueA, float inValueB) {
        return inValueA * inValueB >= 0.0f;
    }

    public static float getValueRatioInRange(
        float inMinimum, float inMaximum, float inValue, float inMinimumRange = 0.001f)
    {
        float theRange = inMaximum - inMinimum;
        return equalsWithPrecision(theRange, 0.0f, inMinimumRange) ? 0.0f : inValue / theRange;
    }

    //Angles
    public static float getNearestAngleBetweenPoints(Vector2 inPointFrom, Vector2 inPointTo) {
        Vector2 theDelta = inPointTo - inPointFrom;
        return Mathf.Atan2(theDelta.y, theDelta.x) * Mathf.Rad2Deg;
    }

    public static float getNormalizedAngle(float inAngle) {
        float theAngle = inAngle % 360.0f;
        return theAngle > 180.0f ? theAngle - 360.0f :
            theAngle < -180.0f ? theAngle + 360.0f : theAngle;
    }

    public static float getNormalizedAnglesClockwiseDelta(float inFrom, float inTo) {
        float theDelta = inTo - inFrom;
        if (theDelta < 0.0f) theDelta += 360;
        return theDelta;
    }

    //Transform
    public static void assignTransform(Transform outTo, Transform inFrom) {
        outTo.position = inFrom.position;
        outTo.rotation = inFrom.rotation;
        outTo.localScale = inFrom.localScale;
    }
}

using UnityEngine;
using UniVRM10;

[ExecuteAlways]
[DisallowMultipleComponent]
public class VrmExpressionFloatDriver : MonoBehaviour
{
    [Header("Target")]
    public Vrm10Instance vrm;

    [Header("Presets")]
    [Range(0, 1)] public float neutral;
    [Range(0, 1)] public float happy;
    [Range(0, 1)] public float angry;
    [Range(0, 1)] public float sad;
    [Range(0, 1)] public float relaxed;
    [Range(0, 1)] public float surprised;

    [Header("Blink")]
    [Range(0, 1)] public float blink;
    [Range(0, 1)] public float blinkLeft;
    [Range(0, 1)] public float blinkRight;

    [Header("Visemes")]
    [Range(0, 1)] public float aa;
    [Range(0, 1)] public float ih;
    [Range(0, 1)] public float ou;
    [Range(0, 1)] public float ee;
    [Range(0, 1)] public float oh;

    [Header("Look (only affects eyes if LookAtType = Expression)")]
    [Range(0, 1)] public float lookUp;
    [Range(0, 1)] public float lookDown;
    [Range(0, 1)] public float lookLeft;
    [Range(0, 1)] public float lookRight;

    [Header("Options")]
    [Tooltip("If enabled, the driver will set unspecified standard keys to 0 each apply to avoid stale weights.")]
    public bool zeroOthers = false;

    void Reset()
    {
        if (!vrm) vrm = GetComponentInParent<Vrm10Instance>();
        if (!vrm) vrm = GetComponent<Vrm10Instance>();
    }

    void OnEnable()
    {
        if (!vrm) Reset();
        ApplyNow();
    }

    void OnValidate()
    {
        ApplyNow();
    }

    void LateUpdate()
    {
        if (Application.isPlaying) ApplyNow();
    }

    void OnDidApplyAnimationProperties()
    {
        // Required for Timeline/Animation preview in edit mode
        ApplyNow();
    }

    void ApplyNow()
    {
        if (!vrm || vrm.Runtime == null || vrm.Runtime.Expression == null) return;

        var exp = vrm.Runtime.Expression;

        if (zeroOthers)
        {
            // Clear all known keys first (prevents stale weights when you stop animating a field)
            exp.SetWeight(ExpressionKey.Neutral, 0);
            exp.SetWeight(ExpressionKey.Happy, 0);
            exp.SetWeight(ExpressionKey.Angry, 0);
            exp.SetWeight(ExpressionKey.Sad, 0);
            exp.SetWeight(ExpressionKey.Relaxed, 0);
            exp.SetWeight(ExpressionKey.Surprised, 0);

            exp.SetWeight(ExpressionKey.Blink, 0);
            exp.SetWeight(ExpressionKey.BlinkLeft, 0);
            exp.SetWeight(ExpressionKey.BlinkRight, 0);

            exp.SetWeight(ExpressionKey.Aa, 0);
            exp.SetWeight(ExpressionKey.Ih, 0);
            exp.SetWeight(ExpressionKey.Ou, 0);
            exp.SetWeight(ExpressionKey.Ee, 0);
            exp.SetWeight(ExpressionKey.Oh, 0);

            exp.SetWeight(ExpressionKey.LookUp, 0);
            exp.SetWeight(ExpressionKey.LookDown, 0);
            exp.SetWeight(ExpressionKey.LookLeft, 0);
            exp.SetWeight(ExpressionKey.LookRight, 0);
        }

        // Presets
        exp.SetWeight(ExpressionKey.Neutral, Mathf.Clamp01(neutral));
        exp.SetWeight(ExpressionKey.Happy, Mathf.Clamp01(happy));
        exp.SetWeight(ExpressionKey.Angry, Mathf.Clamp01(angry));
        exp.SetWeight(ExpressionKey.Sad, Mathf.Clamp01(sad));
        exp.SetWeight(ExpressionKey.Relaxed, Mathf.Clamp01(relaxed));
        exp.SetWeight(ExpressionKey.Surprised, Mathf.Clamp01(surprised));

        // Blink
        exp.SetWeight(ExpressionKey.Blink, Mathf.Clamp01(blink));
        exp.SetWeight(ExpressionKey.BlinkLeft, Mathf.Clamp01(blinkLeft));
        exp.SetWeight(ExpressionKey.BlinkRight, Mathf.Clamp01(blinkRight));

        // Visemes
        exp.SetWeight(ExpressionKey.Aa, Mathf.Clamp01(aa));
        exp.SetWeight(ExpressionKey.Ih, Mathf.Clamp01(ih));
        exp.SetWeight(ExpressionKey.Ou, Mathf.Clamp01(ou));
        exp.SetWeight(ExpressionKey.Ee, Mathf.Clamp01(ee));
        exp.SetWeight(ExpressionKey.Oh, Mathf.Clamp01(oh));

        // Look (only meaningful if LookAtType = Expression on the VRM)
        exp.SetWeight(ExpressionKey.LookUp, Mathf.Clamp01(lookUp));
        exp.SetWeight(ExpressionKey.LookDown, Mathf.Clamp01(lookDown));
        exp.SetWeight(ExpressionKey.LookLeft, Mathf.Clamp01(lookLeft));
        exp.SetWeight(ExpressionKey.LookRight, Mathf.Clamp01(lookRight));

        // 🔥 Push weights to meshes for edit-time preview / Timeline scrubbing
        vrm.Runtime.Process();
    }
}
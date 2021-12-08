using UnityEngine;

public class SwapAttack : MonoBehaviour
{
	public AnimationClip[] WeaponAnimationClip;
	public string[] WeaponNames;
	public KeyCode NextWeaponKeyCode;
	// public string AOControllerSlotName;

	Animator animator;
	AnimatorOverrideController animatorOverrideController;

	int weaponIndex = 0;
    AnimationClipOverrides clipOverrides;


	public void Start()
	{
		animator = GetComponent<Animator>();
		weaponIndex = 0;

        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animatorOverrideController.name = "runtimeAnimatorOverrideCtrl";
        animator.runtimeAnimatorController = animatorOverrideController;

        clipOverrides = new AnimationClipOverrides(animatorOverrideController.overridesCount);
		animatorOverrideController.GetOverrides(clipOverrides);
    }

	public void Update()
	{
		if (Input.GetKeyDown(NextWeaponKeyCode))
		{
            Debug.Log($"ChangingAnimationClips {weaponIndex}");
            weaponIndex = (weaponIndex + 1) % WeaponAnimationClip.Length;
            clipOverrides[WeaponNames[0]] = WeaponAnimationClip[weaponIndex];
            // clipOverrides[WeaponNames[2]] = clipOverrides[WeaponNames[0]];
            // clipOverrides[WeaponNames[1]] = WeaponAnimationClip[weaponIndex];
            Debug.Log(clipOverrides[WeaponNames[0]]);
            animatorOverrideController.ApplyOverrides(clipOverrides);
		}
	}

	private void OnGUI()
	{
		GUI.TextField(new Rect(30, 30, 200, 50), $"Current Attack: {WeaponNames[weaponIndex]}");
	}
}
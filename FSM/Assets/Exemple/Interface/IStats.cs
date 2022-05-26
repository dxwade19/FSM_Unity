using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public interface IStats
{
	event Action<bool> OnNeedHeal;
	event Action<float> OnLife;
	event Action OnDie;

	bool IsDead { get; }

	bool NeedHeal { get; }
	float Life { get; }
	void SetDamage(float _dmg);

	void AddLife(float _life);
}

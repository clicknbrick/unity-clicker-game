using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Quest {

	public int QuestID;
	public string QuestType;
	public string TargetName;
	public int GoalPerLevel;
	public string RewardType;
	public int RewardAmountPerLevel;
}

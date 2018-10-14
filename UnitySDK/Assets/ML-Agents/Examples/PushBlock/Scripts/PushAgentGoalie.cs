//Put this script on your blue cube.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;

public class PushAgentGoalie : PushAgentBasic
{
     public override void InitializeAgent()
    {
        base.InitializeAgent();
        goalDetect = block.GetComponent<GoalDetect>();
        goalDetect.agentGoalie = this;
    }


    /// <summary>
    /// Called when an agent moves the block into the goal.
    /// </summary>
    public override void IScoredAGoal()
    {
        // We use a penalty of -5.
        AddReward(-5f);

        // By marking an agent as done AgentReset() will be called automatically.
        Done();
    }

    /// <summary>
    /// Called every step of the engine. Here the agent takes an action.
    /// </summary>
	public override void AgentAction(float[] vectorAction, string textAction)
    {
        // Move the agent using the action.
        MoveAgent(vectorAction);

        // Reward given each step to encourage agent to prolong the game.
        AddReward(1f / agentParameters.maxStep);
    }
}

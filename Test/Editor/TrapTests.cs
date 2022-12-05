using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using NSubstitute;

public class TrapTests
{
    [Test]
    public void PlayerEntering_PlayerTargetedTrap_ReducesHealthByOne()
    {
        Trap trap = new Trap();
        ICharacterMover characterMover = Substitute.For<ICharacterMover>();
        characterMover.IsPlayer.Returns(true);

        trap.HandleCharacterEntered(characterMover, TrapTargetType.Player);
        
        Assert.AreEqual(-1, characterMover.Health);
    }

    [Test]
    public void NpcEntering_NpcTargetedTrap_ReducesHealthByOne()
    {
        Trap trap = new Trap();
        ICharacterMover characterMover = Substitute.For<ICharacterMover>();

        trap.HandleCharacterEntered(characterMover, TrapTargetType.Npc);

        Assert.AreEqual(-1, characterMover.Health);
    }

    [Test]
    public void PlayerEntering_PlayerTargetedTrap_ReducesHealthByFive()
    {
        Trap trap = new Trap();
        ICharacterMover characterMover = Substitute.For<ICharacterMover>();

        trap.HandleCharacterEntered(characterMover, TrapTargetType.PlayerDecreasedByFive);

        Assert.AreEqual(-5, characterMover.Health);
    }

    [Test]
    public void PlayerEntering_PlayerTargetedTrap_ImprovesHealthByFive()
    {
        Trap trap = new Trap();
        ICharacterMover characterMover = Substitute.For<ICharacterMover>();

        trap.HandleCharacterEntered(characterMover, TrapTargetType.PlayerImproveByFive);

        Assert.AreEqual(+5, characterMover.Health);
    }
}

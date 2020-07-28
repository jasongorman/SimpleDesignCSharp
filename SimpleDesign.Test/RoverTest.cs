using NUnit.Framework;

namespace SimpleDesign.Test
{
    [TestFixture]
    public class RoverTest
    {
        [TestCase("N", "E")]
        [TestCase("E", "S")]
        [TestCase("S", "W")]
        [TestCase("W", "N")]
        public void TurnsRightClockwise(string starts, string ends)
        {
            Rover rover = new Rover(starts, new int[] {0, 0});
            rover.Go("R");
            Assert.AreEqual(ends, rover.Facing);
        }
        
        [TestCase("N", "W")]
        [TestCase("W", "S")]
        [TestCase("S", "E")]
        [TestCase("E", "N")]
        public void TurnsLeftAntiClockwise(string starts, string ends)
        {
            Rover rover = new Rover(starts, new int[] {0, 0});
            rover.Go("L");
            Assert.AreEqual(ends, rover.Facing);
        }

        [TestCase("N", new int[]{5, 5}, new int[]{5, 6})]
        [TestCase("E", new int[]{5, 5}, new int[]{6, 5})]
        [TestCase("S", new int[]{5, 5}, new int[]{5, 4})]
        [TestCase("W", new int[]{5, 5}, new int[]{4, 5})]
        public void MovesForwardInDirectionFacing(string facing, int[] startCoords, int[] endCoords)
        {
            Rover rover = new Rover(facing, startCoords);
            rover.Go("F");
            CollectionAssert.AreEqual(endCoords, rover.Coordinates);
        }
        
        [TestCase("N", new int[]{5, 5}, new int[]{5, 4})]
        [TestCase("E", new int[]{5, 5}, new int[]{4, 5})]
        [TestCase("S", new int[]{5, 5}, new int[]{5, 6})]
        [TestCase("W", new int[]{5, 5}, new int[]{6, 5})]
        public void MovesBackwardsFromDirectionFacing(string facing, int[] startCoords, int[] endCoords)
        {
            Rover rover = new Rover(facing, startCoords);
            rover.Go("B");
            CollectionAssert.AreEqual(endCoords, rover.Coordinates);
        }

        [Test]
        public void ExecutesSequenceOfInstructions()
        {
            Rover rover = new Rover("N", new int[]{6, 7});
            rover.Go("RFF");
            Assert.AreEqual("E", rover.Facing);
            CollectionAssert.AreEqual(new int[]{8, 7}, rover.Coordinates);
        }
    }
}
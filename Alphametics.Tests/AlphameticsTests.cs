namespace Alphametics.Tests;

using Alphametics.Processing;
using Alphametics.Processing.PartialProcessing;
using static Alphametics.Assignment.AssignmentManager;
using static Alphametics.Validation.Validator;
using static Alphametics.HelperMethods.Helpers;

[Collection("Sequential")]
public class AlphameticsTests
{
    [Fact]
    public void AssignNumbers_ShouldAssignCorrectlyFor_IBbIll()
    {
        //Arrange
        ResetCollections();

        //Act
        int[] result = Assigner.AssignNumbers("I", "BB", "ILL");

        //Assert
        Assert.Equal([1, 99, 100], result);
    }

    [Fact]
    public void AssignNumbers_ShouldAssignCorrectlyFor_ElfElfFool()
    {
        //Arrange
        ResetCollections();

        //Act
        int[] result = Assigner.AssignNumbers("ELF", "ELF", "FOOL");

        //Assert
        Assert.Equal([721, 721, 1442], result);
    }

    [Fact]
    public void AssignNumbers_ShouldAssignCorrectlyFor_HeadToeWaist()
    {
        //Arrange
        ResetCollections();

        //Act
        int[] result = Assigner.AssignNumbers("HEAD", "TOE", "WAIST");

        //Assert
        Assert.Equal([9708, 537, 10245], result);
    }

    [Fact]
    public void AssignNumbers_ShouldAssignCorrectlyFor_OoohFoodFight()
    {
        //Arrange
        ResetCollections();

        //Act
        int[] result = Assigner.AssignNumbers("OOOH", "FOOD", "FIGHT");

        //Assert
        Assert.Equal([8886, 1883, 10769], result);
    }

    [Fact]
    public void AssignNumbers_ShouldAssignCorrectlyFor_HereSheComes()
    {
        //Arrange
        ResetCollections();

        //Act
        int[] result = Assigner.AssignNumbers("HERE", "SHE", "COMES");

        //Assert
        Assert.Equal([9454, 894, 10348], result);
    }

    [Fact]
    public void AssignNumbers_ShouldAssignCorrectlyFor_EatThatApple()
    {
        //Arrange
        ResetCollections();

        //Act
        int[] result = Assigner.AssignNumbers("EAT", "THAT", "APPLE");

        //Assert
        Assert.Equal([819, 9219, 10038], result);
    }

    [Fact]
    public void AssignNumbers_ShouldAssignCorrectlyFor_FiftyStatesAmerica()
    {
        //Arrange
        ResetCollections();

        //Act
        int[] result = Assigner.AssignNumbers("FIFTY", "STATES", "AMERICA");

        //Assert
        Assert.Equal([65682, 981849, 1047531], result);
    }

    [Fact]
    public void AssignNumbers_ShouldAssignCorrectlyFor_NumberNumberPuzzle()
    {
        //Arrange
        ResetCollections();

        //Act
        int[] result = Assigner.AssignNumbers("NUMBER", "NUMBER", "PUZZLE");

        //Assert
        Assert.Equal([201689, 201689, 403378], result);
    }

    [Fact]
    public void AssignNumbers_ShouldAssignCorrectlyFor_SendMoreMoney()
    {
        //Arrange
        ResetCollections();

        //Act
        int[] result = Assigner.AssignNumbers("SEND", "MORE", "MONEY");

        //Assert
        Assert.Equal([9567, 1085, 10652], result);
    }

    [Fact]
    public void AssignNumbers_ShouldAssignCorrectlyFor_TwoWrongsMakeARight()
    {
        //Arrange
        ResetCollections();

        //Act
        int[] result = Assigner.AssignNumbers("WRONG", "WRONG", "RIGHT");

        //Assert
        Assert.Equal([37081, 37081, 74162], result);
    }

    [Fact]
    public void AssignNumbers_ShouldAssignCorrectlyFor_LettersAlphabetScrabble()
    {
        //Arrange
        ResetCollections();

        //Act
        int[] result = Assigner.AssignNumbers("LETTERS", "ALPHABET", "SCRABLLE");

        //Assert
        Assert.Equal([], result);
    }

    [Fact]
    public void Assign_ShouldAssignAValueOnlyIfAvailable()
    {
        // Arrange
        ResetCollections();
        Assign('A', 1);

        // Act
        bool result = Assign('B', 1);

        // Assert
        Assert.False(result);
    }

    [Fact]
    public void Assign_ShouldAssignAValueIfNotAlreadyAssigned()
    {
        // Arrange
        ResetCollections();

        // Act
        bool result = Assign('A', 1);

        // Assert
        Assert.True(result);
        Assert.Equal('A', AssignedAt(1));
    }

    [Fact]
    public void Assign_ShouldReturnTrueIfSameValueIsAlreadyAssigned()
    {
        // Arrange
        ResetCollections();
        Assign('A', 1);

        // Act
        bool result = Assign('A', 1);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ValidAssigned_ShouldReturnTrueIfAllValuesAreUnique()
    {
        // Arrange
        ResetCollections();
        SetSequences("A", "B", "C");
        AssignColumn(ColumnCharacters(1), (1, 2, 3));

        // Act
        bool result = ValidAssigned();

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void SequencesAsInt_ShouldConvertStringsToNumbersBasedOnAssignedValues()
    {
        // Arrange
        ResetCollections();
        SetSequences("SEND", "MORE", "MONEY");
        Assign('S', 9);
        Assign('E', 5);
        Assign('N', 6);
        Assign('D', 7);
        Assign('M', 1);
        Assign('O', 0);
        Assign('R', 8);
        Assign('Y', 2);

        // Act
        int[] result = SequencesAsInt();

        // Assert
        Assert.Equal([9567, 1085, 10652], result);
    }

    [Fact]
    public void ColumnCharacters_ShouldReturnDotForOutOfBoundsCharacters()
    {
        // Arrange
        ResetCollections();
        SetSequences("SEND", "MORE", "MONEY");

        // Act
        char[] result = ColumnCharacters(6);

        // Assert
        Assert.Equal(['.', '.', '.'], result);
    }

    [Fact]
    public void ReducedSet_ShouldReturnValidCombinationsForEmptyColumns()
    {
        // Arrange
        ResetCollections();
        char[] column = ['.', '.', 'M'];
        int[] setIndices = [-1, -1, -1];
        int carryOver = 1;

        // Act
        var result = PartialValueGenerator.ReducedSet(column, setIndices, carryOver).First();

        // Assert
        Assert.Equal((-2, -2, 1), result);
    }

    [Fact]
    public void TwoSet_ShouldReturnValidCombinationsWhenTwoIndicesAreSet()
    {
        // Arrange
        ResetCollections();
        int[] setIndices = [1, 2, -1];
        int carryOver = 0;

        // Act
        var result = ValueGenerator.TwoSet(setIndices, carryOver).First();

        // Assert
        Assert.Equal((1, 2, 3), result);
    }

    [Fact]
    public void ResetCollections_ShouldResetAllStaticVariables()
    {
        // Arrange
        ResetCollections();
        Assign('A', 1);

        // Act
        ResetCollections();

        // Assert
        Assert.Equal('?', AssignedAt(1));
    }
}

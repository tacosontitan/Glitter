﻿/*
   Copyright 2023 tacosontitan and contributors

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

namespace Glitter.Tests.Core;

public class ClampedTests
{
    [Fact]
    public void Constructor_LessThanLowerBound_ClampsToLowerBound()
    {
        // Arrange
        int value = 0;
        int lowerBound = 1;
        int upperBound = 10;

        // Act
        Clamped<int> clamped = new(value, lowerBound, upperBound);

        // Assert
        Assert.Equal(lowerBound, clamped.Value);
    }

    [Fact]
    public void Constructor_GreaterThanUpperBound_ClampsToUpperBound()
    {
        // Arrange
        int value = 100;
        int lowerBound = 1;
        int upperBound = 10;

        // Act
        Clamped<int> clamped = new(value, lowerBound, upperBound);

        // Assert
        Assert.Equal(upperBound, clamped.Value);
    }

    [Fact]
    public void Constructor_WithinBounds_DoesNotAdjust()
    {
        // Arrange
        int value = 5;
        int lowerBound = 1;
        int upperBound = 10;

        // Act
        Clamped<int> clamped = new(value, lowerBound, upperBound);

        // Assert
        Assert.Equal(value, clamped.Value);
    }

    [Fact]
    public void LowerBoundSet_GreaterThanValue_ClampsToLowerBound()
    {
        // Arrange
        int value = 5;
        int lowerBound = 1;
        int upperBound = 15;
        Clamped<int> clamped = new(value, lowerBound, upperBound);

        // Act
        clamped.LowerBound = value + 1;

        // Assert
        Assert.Equal(clamped.LowerBound, clamped.Value);
    }

    [Fact]
    public void LowerBoundSet_LessThanValue_DoesNotAdjust()
    {
        // Arrange
        int value = 5;
        int lowerBound = 1;
        int upperBound = 15;
        Clamped<int> clamped = new(value, lowerBound, upperBound);

        // Act
        clamped.LowerBound = value - 1;

        // Assert
        Assert.Equal(value, clamped.Value);
    }

    [Fact]
    public void UpperBoundSet_LessThanValue_ClampsToUpperBound()
    {
        // Arrange
        int value = 5;
        int lowerBound = 1;
        int upperBound = 15;
        Clamped<int> clamped = new(value, lowerBound, upperBound);

        // Act
        clamped.UpperBound = value - 1;

        // Assert
        Assert.Equal(clamped.UpperBound, clamped.Value);
    }

    [Fact]
    public void UpperBoundSet_GreaterThanValue_DoesNotAdjust()
    {
        // Arrange
        int value = 5;
        int lowerBound = 1;
        int upperBound = 15;
        Clamped<int> clamped = new(value, lowerBound, upperBound);

        // Act
        clamped.UpperBound = value + 1;

        // Assert
        Assert.Equal(value, clamped.Value);
    }

    [Fact]
    public void ImplicitConversion_NullInput_ThrowsArgumentNullException()
    {
        // Arrange
        Clamped<int> clamped = null!;

        // Act
        void TestAction()
        {
            int value = clamped;
        }

        // Assert
        Assert.Throws<ArgumentNullException>(TestAction);
    }
}
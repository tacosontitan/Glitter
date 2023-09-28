/*
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
    public void Constructor_LessThanLowerBound_ConstrainsToLowerBound()
    {
        // Arrange
        int value = 0;
        int lowerBound = 1;
        int upperBound = 10;
        
        // Act
        Clamped<int> clamped = new(value, lowerBound, upperBound);
        
        // Assert
        Assert.Equal(expected: lowerBound, actual: clamped.Value);
    }
    
    [Fact]
    public void Constructor_GreaterThanUpperBound_ConstrainsToUpperBound()
    {
        // Arrange
        int value = 100;
        int lowerBound = 1;
        int upperBound = 10;
        
        // Act
        Clamped<int> clamped = new(value, lowerBound, upperBound);
        
        // Assert
        Assert.Equal(expected: upperBound, actual: clamped.Value);
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
        Assert.Equal(expected: value, actual: clamped.Value);
    }
    
    [Fact]
    public void LowerBoundSet_GreaterThanValue_ConstrainsToLowerBound()
    {
        // Arrange
        int value = 5;
        int lowerBound = 1;
        int upperBound = 15;
        Clamped<int> clamped = new(value, lowerBound, upperBound);
        
        // Act
        clamped.LowerBound = value + 1;
        
        // Assert
        Assert.Equal(expected: clamped.LowerBound, actual: clamped.Value);
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
        Assert.Equal(expected: value, actual: clamped.Value);
    }
    
    [Fact]
    public void UpperBoundSet_LessThanValue_ConstrainsToUpperBound()
    {
        // Arrange
        int value = 5;
        int lowerBound = 1;
        int upperBound = 15;
        Clamped<int> clamped = new(value, lowerBound, upperBound);
        
        // Act
        clamped.UpperBound = value - 1;
        
        // Assert
        Assert.Equal(expected: clamped.UpperBound, actual: clamped.Value);
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
        Assert.Equal(expected: value, actual: clamped.Value);
    }
}
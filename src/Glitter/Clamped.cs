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

namespace Glitter;

/// <summary>
/// Represents a constrained value.
/// </summary>
/// <typeparam name="T">Specifies the type of the value.</typeparam>
public class Clamped<T>
    where T : IComparable<T>
{
    private T _value;
    private T _lowerBound;
    private T _upperBound;

    /// <summary>
    /// Creates a new constrained value.
    /// </summary>
    /// <param name="value">The initial value.</param>
    /// <param name="lowerBound">The lower bound of the constrained value.</param>
    /// <param name="upperBound">The upper bound of the constrained value.</param>
    public Clamped(T value, T lowerBound, T upperBound)
    {
        _lowerBound = lowerBound;
        _upperBound = upperBound;
        _value = Clamp(value);
    }

    /// <summary>
    /// Gets or sets the lower bound of the constrained value.
    /// </summary>
    /// <remarks>Adjusting the lower bound will also adjust the current value to retain constraints.</remarks>
    public T LowerBound
    {
        get => _lowerBound;
        set
        {
            _lowerBound = value;
            if (_value.CompareTo(_lowerBound) < 0)
                _value = _lowerBound;
        }
    }

    /// <summary>
    /// Gets or sets the upper bound of the constrained value.
    /// </summary>
    /// <remarks>Adjusting the upper bound will also adjust the current value to retain constraints.</remarks>
    public T UpperBound
    {
        get => _upperBound;
        set
        {
            _upperBound = value;
            if (_value.CompareTo(_upperBound) > 0)
                _value = _upperBound;
        }
    }

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    public T Value
    {
        get => _value;
        set => _value = Clamp(value);
    }

    private T Clamp(T value)
    {
        if (value.CompareTo(_lowerBound) < 0)
            return _lowerBound;

        if (value.CompareTo(_upperBound) > 0)
            return _upperBound;

        return value;
    }

    /// <summary>
    /// Implicitly converts a <see cref="Clamped{T}"/> to a <typeparamref name="T"/>.
    /// </summary>
    /// <param name="input">The <see cref="Clamped{T}"/> to convert.</param>
    /// <returns>The value of the <see cref="Clamped{T}"/>.</returns>
    public static implicit operator T(Clamped<T> input)
    {
        if (input is null)
            throw new ArgumentNullException(nameof(input));

        return input.Value;
    }
}
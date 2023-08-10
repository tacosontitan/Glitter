﻿namespace Glitter;

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
        _value = Constrain(value);
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
        set => _value = Constrain(value);
    }

    private T Constrain(T value)
    {
        if (value.CompareTo(_lowerBound) < 0)
            return _lowerBound;

        if (value.CompareTo(_upperBound) > 0)
            return _upperBound;

        return value;
    }
}

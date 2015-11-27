﻿namespace Gu.Units
{
    using System;
    using System.Globalization;

    internal static class QuantityParser
    {
        internal static TQuantity Parse<TUnit, TQuantity>(string text,
            Func<double, TUnit, TQuantity> creator,
            NumberStyles style,
            IFormatProvider provider)
            where TQuantity : IQuantity<TUnit>
            where TUnit : struct, IUnit
        {
            int pos;
            double d;
            if (!DoubleReader.TryRead(text, 0, style, provider, out d, out pos))
            {
                throw new FormatException("Could not parse the scalar value from: " + text);
            }

            text.ReadWhiteSpace(ref pos);
            TUnit unit;
            if (!UnitParser<TUnit>.TryParse(text, ref pos, out unit))
            {
                throw new FormatException("Could not parse the unit value from: " + text);
            }

            text.ReadWhiteSpace(ref pos);
            if (pos != text.Length)
            {
                throw new FormatException("Could not parse the unit value from: " + text);
            }

            return creator(d, unit);
        }

        internal static bool TryParse<TUnit, TQuantity>(string text,
            Func<double, TUnit, TQuantity> creator,
            NumberStyles style,
            IFormatProvider provider,
            out TQuantity value) 
            where TQuantity : IQuantity<TUnit>
            where TUnit : struct, IUnit
        {
            int pos;
            double d;
            if (!DoubleReader.TryRead(text, 0, style, provider, out d, out pos))
            {
                value = default(TQuantity);
                return false;
            }

            text.ReadWhiteSpace(ref pos);

            TUnit unit;
            if (!UnitParser<TUnit>.TryParse(text, ref pos, out unit))
            {
                value = default(TQuantity);
                return false;
            }

            text.ReadWhiteSpace(ref pos);
            if (pos != text.Length)
            {
                value = default(TQuantity);
                return false;
            }

            value = creator(d, unit);
            return true;
        }
    }
}